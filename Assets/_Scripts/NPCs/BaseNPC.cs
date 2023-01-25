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
        public Convensation[] convensation;
        protected bool isTalking;

        protected abstract void OnTriggerEnter2D(Collider2D other);
        
        protected abstract void OnTriggerStay2D(Collider2D other);

        protected abstract void OnTriggerExit2D(Collider2D other);

    }
    
    [Serializable]
    public class Convensation
    {
        public string name;
        public string text;
    }
}