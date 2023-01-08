using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Timekeeper;
using Timekeeper.CoreSystem;

public class GameManager : Singleton<GameManager>
{
    
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private float respawnTime;
    [SerializeField] private Stats stats;
    

    private float respawnTimeStart;

    private bool respawn;
    public bool isDeath;
    public Animator DeathUI;

    // private CinemachineVirtualCamera CVC;
    //
    // private void Start()
    // {
    //     CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();
    // }

    private void Awake()
    {
        DeathUI = GameObject.Find("DeathUI").GetComponent<Animator>();
    }

    private void Update()
    {
        CheckRespawn();
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
