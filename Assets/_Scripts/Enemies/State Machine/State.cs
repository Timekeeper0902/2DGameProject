using System.Collections;
using System.Collections.Generic;
using Timekeeper._Panel;
using Timekeeper.CoreSystem;
using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine;
    protected BaseAudioData baseAudioData;
    protected Entity entity;
    protected Core core;    

    public float startTime { get; protected set; }

    protected string animBoolName;

    public State(Entity entity, FiniteStateMachine stateMachine, BaseAudioData baseAudioData,string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        this.baseAudioData = baseAudioData;
        core = this.entity.Core;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        DoChecks();
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}
