using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Timekeeper.NPCs
{
    public class OldMan : BaseNPC
    {
        //对话计数
        private int i = 0;
        private bool check = false;
        
        private void Update()
        {
            
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            PlayerInputHandler.Instance.SetSpaceInputZero();
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
                }
                
                if (isTalking)
                {
                    if (PlayerInputHandler.Instance.SpaceInput >= conversation.dialogs.Length)
                    {
                        textUI.gameObject.SetActive(false);
                        dialog.gameObject.SetActive(false);
                        isTalking = false;
                        PlayerInputHandler.Instance.SetSpaceInputZero();
                    }
                    dialogName.text = conversation.dialogs[PlayerInputHandler.Instance.SpaceInput].name;
                    dialogText.text = conversation.dialogs[PlayerInputHandler.Instance.SpaceInput].speak;
                }
            }
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                textUI.gameObject.SetActive(false);
                dialog.gameObject.SetActive(false);
                PlayerInputHandler.Instance.SetSpaceInputZero();
                isTalking = false;
            }
        }
    }
}