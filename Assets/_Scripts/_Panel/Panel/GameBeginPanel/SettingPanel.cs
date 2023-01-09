using UnityEngine;
using UnityEngine.UI;

namespace Timekeeper
{
    public class SettingPanel : Singleton<SettingPanel>
    {
        public Button quitBtn;
        public Slider musicSlider;
        public Toggle musicToggle;
        
        public GameObject hideImage;


        private void Start()
        {
            quitBtn.onClick.AddListener(HideMe);
            musicSlider.onValueChanged.AddListener((value => GameDataManager.Instance.ChangeMusicValue(value)));
            musicToggle.onValueChanged.AddListener((value => GameDataManager.Instance.OpenOrCloseMusic(value)));
            HideMe();
        }
        
        private void Update()
        {
            if (musicToggle.isOn)
            {
                hideImage.SetActive(false);
            }
            else
            {
                hideImage.SetActive(true);
            }
        }
        
        public void UpdatePanelInfo()
        {
            //面板数据根据音效数据更新
            MusicData data = GameDataManager.Instance._musicData;

            musicSlider.value = data.musicValue;
            musicToggle.isOn = data.isOpenBk;
        }

        public override void ShowMe()
        {
            base.ShowMe();
        
            //每次显示面板时顺便更新
            UpdatePanelInfo();
        }
    }
    
    
}