using System;
using UnityEngine;
using UnityEngine.UI;

namespace Timekeeper
{
    public class ReSpawnPlace : MonoBehaviour
    {
        public Text ui;
        private Transform respawnPlaceLight;
        private bool isRespawmPoint;


        private void Start()
        {
            respawnPlaceLight = GameObject.Find("RespawnPlaceLight").GetComponent<Transform>();
        }

        private void Update()
        {
            CheckIfReSpawnPoint();
        }

        private void CheckIfReSpawnPoint()
        {
            if (ReSpawnManager.Instance.respawnPoint.position == this.transform.position)
            {
                respawnPlaceLight.transform.position = this.transform.position;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                ui.gameObject.SetActive(true);
                ui.text = "按下E键保存当前重生位置";
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                if (PlayerInputHandler.Instance.ActiveInput)
                {
                    ReSpawnManager.Instance.respawnPoint.position = this.transform.position;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                ui.gameObject.SetActive((false));
            }
        }
    }
}