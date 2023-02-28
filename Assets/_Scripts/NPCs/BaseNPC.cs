using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Timekeeper.NPCs
{
    public abstract class BaseNPC : MonoBehaviour
    {
        public Text textUI;
        public Image dialog;
        public Text dialogText;
        public Text dialogName;
        public Conversation conversation;
        protected bool isTalking;

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                textUI.text = "按E对话";
                textUI.gameObject.SetActive(true);
            }
        }
        
        protected abstract void OnTriggerStay2D(Collider2D other);

        protected abstract void OnTriggerExit2D(Collider2D other);

    }
}