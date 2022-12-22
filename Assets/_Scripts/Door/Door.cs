using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Timekeeper
{
    public class Door : MonoBehaviour
    {
        private GameObject _player;

        private void Awake()
        {
            _player = GameObject.Find("Player").gameObject;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                print("切换");
                SceneManager.LoadScene(1);
                _player.gameObject.transform.position= new Vector2(-36.6f, 0);
            }
        }
    }
}
