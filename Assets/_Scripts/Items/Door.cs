using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Timekeeper
{
    public class Door : MonoBehaviour
    {
        private GameObject _player;
        private bool _cantSwichDoor;
        public Text text;

        private void Awake()
        {
            _player = GameObject.Find("Player").gameObject;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _cantSwichDoor = GameObject.FindWithTag("Enemy");
            
            if (_cantSwichDoor)
            {
                if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
                {
                    LoadManager.Instance.LoadNextLevel();
                    text.text = "你还没有消灭场景中所有的敌人！";
                    text.gameObject.SetActive(true);
                    _player.gameObject.transform.position= new Vector2(-36f, 0);
                }
            }
            else
            {
                if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
                {
                    LoadManager.Instance.LoadNextLevel();
                    _player.gameObject.transform.position= new Vector2(-36f, 0);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                text.gameObject.SetActive(false);
            }
        }
    }
}
