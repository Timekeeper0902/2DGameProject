using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Timekeeper;
using Timekeeper.CoreSystem;
using Timekeeper.Panel.PausePanel;

public class ReSpawnManager : Singleton<ReSpawnManager>
{
    
    public Transform respawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private float respawnTime;
    [SerializeField] private Stats stats;
    //public Transform[] respawnPlace;
    public int deathTimes;
    public  float gameTime;
    public float startTime;


    private float respawnTimeStart;

    private bool respawn;
    public bool isDeath;
    public Animator DeathUI;

    private void Awake()
    {
        DeathUI = GameObject.Find("DeathUI").GetComponent<Animator>();
        startTime = Time.time;
        print(startTime);
    }

    private void Update()
    {
        CheckRespawn();
        gameTime = Time.time - startTime;
    }
    public void Respawn()
    {
        respawnTimeStart = Time.time;
        respawn = true;
    }

    /// <summary>
    /// 重生逻辑
    /// </summary>
    private void CheckRespawn()
    {
        if(Time.time >= respawnTimeStart + respawnTime && respawn)
        {
            deathTimes++;
            stats.ReturnToMaxHealth();
            player.gameObject.transform.position = respawnPoint.position;
            player.SetActive(true);
            // var playerTemp = Instantiate(player, respawnPoint);
            // CVC.m_Follow = playerTemp.transform;
            respawn = false;
            isDeath = false;
            DeathUI.SetBool("death",isDeath);
        }
    }
}
