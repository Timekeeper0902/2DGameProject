using System;
using UnityEngine;

namespace Timekeeper.NPCs
{
    public class OldMan : BaseNPC
    {
        private int i = 0;
        
        private void Update()
        {
            
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                textUI.text = "按E对话";
                textUI.gameObject.SetActive(true);
            }
        }

        protected override void OnTriggerStay2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                if (PlayerInputHandler.Instance.ActiveInput)
                {
                    isTalking = true;
                    textUI.gameObject.SetActive(false);
                    dialog.gameObject.SetActive(true);
                    dialogName.text = convensation[i].name;
                    dialogText.text = convensation[i].text;
                    
                }
            }
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                textUI.gameObject.SetActive(false);
                dialog.gameObject.SetActive(false);
            }
        }
    }
}