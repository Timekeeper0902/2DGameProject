using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Timekeeper;
using Timekeeper.CoreSystem;
using Timekeeper.Panel.PausePanel;

public class GameManager : Singleton<GameManager>
{
    
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private float respawnTime;
    [SerializeField] private Stats stats;
    private PlayerInputHandler _inputHandler;
    

    private float respawnTimeStart;

    //public bool canPause = true;
    private bool respawn;
    public bool isDeath;
    public Animator DeathUI;

    private void Awake()
    {
        _inputHandler = GameObject.Find("Player").GetComponent<PlayerInputHandler>();
        DeathUI = GameObject.Find("DeathUI").GetComponent<Animator>();
    }

    private void Update()
    {
        CheckRespawn();
        //CheckPuaseMemu();
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
    //
    // /// <summary>
    // /// 控制暂停菜单开关
    // /// </summary>
    // private void CheckPuaseMemu()
    // {
    //     if (canPause && _inputHandler.EscInput)
    //     {
    //         print("yes");
    //         PausePanel.Instance.ShowMe();
    //     }
    //     else if (!canPause && _inputHandler.EscInput)
    //     {
    //         PausePanel.Instance.HideMe();
    //     }
    // }
}
