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
                _musicData.soundValue = 1;
                _musicData.isOpenBk = true;
                _musicData.isOpenSound = true;
                PlayerPrefsDataMgr.Instance.SaveData(_musicData,"music");
            }
        }
        /// <summary>
        /// 开启或关闭音乐
        /// </summary>
        /// <param name="isOpen"></param>
        public void OpenOrCloseMusic(bool isOpen)
        {
            _musicData.isOpenBk = isOpen;
            
            MusicSetting.Instance.ChangeOpen(isOpen);
            
            //改变后马上存储
            PlayerPrefsDataMgr.Instance.SaveData(_musicData,"music");
        }
        
        /// <summary>
        /// 开启或关闭音效
        /// </summary>
        /// <param name="isOpen"></param>
        public void OpenOrCloseSound(bool isOpen)
        {
            _musicData.isOpenSound = isOpen;
            
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
        public void ChangeSoundValue(float value)
        {
            _musicData.soundValue = value;
            
            AudioSetting.Instance.ChangeValue(value);
            
            PlayerPrefsDataMgr.Instance.SaveData(_musicData, "music");
        }
    }
}