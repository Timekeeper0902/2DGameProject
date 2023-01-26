using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CombatTestDummy : MonoBehaviour, IDamageable, IKnockbackable
{
    [SerializeField] private GameObject hitParticles;
    public GameObject floatPoint;

    private Animator anim;
    private Rigidbody2D rb;
    
    public bool CanSetVelocity { get; set; }

    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;
    
    private bool isKnockbackActive;
    private float knockbackStartTime;

    public void Damage(float amount)
    {
        Debug.Log(amount + " Damage taken");
        //FloatPoint显示
        GameObject gb = Instantiate(floatPoint,transform.position,Quaternion.identity);
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString(); 

        Instantiate(hitParticles, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        anim.SetTrigger("damage");
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        CheckKnockback();
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        SetVelocity(strength, angle, direction);
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }
    
    private void CheckKnockback() 
    {
        if (isKnockbackActive && ((CurrentVelocity.y <= 0.01f)
                                  || Time.time >= knockbackStartTime + 0.2f)) 
        {
            isKnockbackActive = false;
            CanSetVelocity = true;
        }
    }
    
    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        SetFinalVelocity();
    }
    
    private void SetFinalVelocity()
    {
        if (CanSetVelocity)
        {
            rb.velocity = workspace;
            CurrentVelocity = workspace;
        }        
    }
}
