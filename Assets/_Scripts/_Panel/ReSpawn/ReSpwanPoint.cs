using System;
using UnityEngine;

namespace Timekeeper
{
    public class ReSpwanPoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                ReSpawnManager.Instance.respawnPoint.position = this.transform.position;
            }
        }
    }
}