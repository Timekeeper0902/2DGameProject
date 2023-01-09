using UnityEngine;

namespace Timekeeper
{
    public class MusicSetting : MonoBehaviour
    {
        private static MusicSetting _instance;

        public static MusicSetting Instance => _instance;
        [SerializeField] private AudioSource _audioSource;

        private MusicSetting(){}

        private void Awake()
        {
            _instance = this;
            _audioSource = GetComponent<AudioSource>();
            ChangeValue(GameDataManager.Instance._musicData.musicValue);
            ChangeOpen(GameDataManager.Instance._musicData.isOpenBk);
        }

        /// <summary>
        /// 改变背景音乐大小
        /// </summary>
        /// <param name="value"></param>
        public void ChangeValue(float value)
        {
            _audioSource.volume = value;
        }

        /// <summary>
        /// 是否静音背景音乐
        /// </summary>
        /// <param name="isOpen"></param>
        public void ChangeOpen(bool isOpen)
        {
            _audioSource.mute = !isOpen;
        }
    }
}