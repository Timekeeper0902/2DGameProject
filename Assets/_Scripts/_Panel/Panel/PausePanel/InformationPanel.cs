using System;
using UnityEngine;

namespace Timekeeper.Panel.PausePanel
{
    public class InformationPanel : Singleton<InformationPanel>
    {
        private void Start()
        {
            HideMe();
        }
    }
}