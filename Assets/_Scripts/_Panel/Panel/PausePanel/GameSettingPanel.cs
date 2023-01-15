using UnityEngine;
using UnityEngine.UI;

namespace Timekeeper.Panel.PausePanel
{
    public class GameSettingPanel : Singleton<GameSettingPanel>
    {
        public Toggle musicToggle;
        public Toggle audioToggle;
        public Slider musicSlider;
        public Slider audioSlider;

        public GameObject hideImageMusic;
        public GameObject hideImageAudio;
        
        private void Start()
        {
            musicSlider.onValueChanged.AddListener((value => GameDataManager.Instance.ChangeMusicValue(value)));
            musicToggle.onValueChanged.AddListener((value => GameDataManager.Instance.OpenOrCloseMusic(value)));
            audioSlider.onValueChanged.AddListener((value => GameDataManager.Instance.ChangeAudioValue(value)));
            audioToggle.onValueChanged.AddListener((value => GameDataManager.Instance.OpenOrCloseAudio(value)));
            HideMe();
        }
        
        private void Update()
        {
            if (musicToggle.isOn)
            {
                hideImageMusic.SetActive(false);
            }
            else
            {
                hideImageMusic.SetActive(true);
            }
            
            if (audioToggle.isOn)
            {
                hideImageAudio.SetActive(false);
            }
            else
            {
                hideImageAudio.SetActive(true);
            }
        }
        
        public void UpdatePanelInfo()
        {
            //面板数据根据音效数据更新
            MusicData data = GameDataManager.Instance._musicData;

            musicSlider.value = data.musicValue;
            musicToggle.isOn = data.isOpenMusic;
            audioSlider.value = data.audioValue;
            audioToggle.isOn = data.isOpenAudio;
        }
        
        
        public override void ShowMe()
        {
            base.ShowMe();
        
            //每次显示面板时顺便更新
            UpdatePanelInfo();
        }
    }
}