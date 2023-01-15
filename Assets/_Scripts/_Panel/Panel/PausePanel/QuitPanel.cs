using System;
using UnityEngine;
using UnityEngine.UI;

namespace Timekeeper.Panel.PausePanel
{
    public class QuitPanel : Singleton<QuitPanel>
    {
        public Button yes;
        public Button no;

        private void Start()
        {
            yes.onClick.AddListener((() => Application.Quit()));
            no.onClick.AddListener(HideMe);
            HideMe();
        }
    }
}