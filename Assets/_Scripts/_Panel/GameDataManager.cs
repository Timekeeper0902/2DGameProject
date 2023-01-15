using UnityEngine;

namespace Timekeeper
{
    public class GameDataManager
    {
        private static GameDataManager instance = new GameDataManager();

        public static GameDataManager Instance
        {
            get => instance;
        }
        //音效数据对象
        public MusicData _musicData;

        private GameDataManager()
        {
            //可以去初始化游戏数据
            _musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"music") as MusicData;
            //如果第一次进入游戏没有初始数据，那么初始数据就是0或false；
            //避免第一次进入游戏默认值不符合逻辑；
            if (!_musicData.notFirstLoad)
            {
                _musicData.notFirstLoad = true;
                _musicData.musicValue = 1;
                _musicData.audioValue = 1;
                _musicData.isOpenMusic = true;
                _musicData.isOpenAudio = true;
                PlayerPrefsDataMgr.Instance.SaveData(_musicData,"music");
            }
        }
        /// <summary>
        /// 开启或关闭音乐
        /// </summary>
        /// <param name="isOpen"></param>
        public void OpenOrCloseMusic(bool isOpen)
        {
            _musicData.isOpenMusic = isOpen;
            
            MusicSetting.Instance.ChangeOpen(isOpen);
            
            //改变后马上存储
            PlayerPrefsDataMgr.Instance.SaveData(_musicData,"music");
        }
        
        /// <summary>
        /// 开启或关闭音效
        /// </summary>
        /// <param name="isOpen"></param>
        public void OpenOrCloseAudio(bool isOpen)
        {
            _musicData.isOpenAudio = isOpen;
            
            AudioSetting.Instance.ChangeOpen(isOpen);
            
            //改变后马上存储
            PlayerPrefsDataMgr.Instance.SaveData(_musicData,"music");
        }
        
        //改变音乐音量大小
        public void ChangeMusicValue(float value)
        {
            _musicData.musicValue = value;
            
            MusicSetting.Instance.ChangeValue(value);
            
            PlayerPrefsDataMgr.Instance.SaveData(_musicData, "music");
        }
        
        //改变音效音量大小
        public void ChangeAudioValue(float value)
        {
            _musicData.audioValue = value;
            
            AudioSetting.Instance.ChangeValue(value);
            
            PlayerPrefsDataMgr.Instance.SaveData(_musicData, "music");
        }
    }
}