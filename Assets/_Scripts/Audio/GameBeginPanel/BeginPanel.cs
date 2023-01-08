using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Timekeeper
{
    public class BeginPanel : Singleton<BeginPanel>
    {
        public Button btnBegin;
        public Button btnSetting;
        public Button btnQuit;

        private void Start()
        {
            btnBegin.onClick.AddListener((() => SceneManager.LoadScene("GameScene")));
            btnSetting.onClick.AddListener(SettingPanel.Instance.ShowMe);
            btnQuit.onClick.AddListener((() => Application.Quit()));
        }
    }
}
