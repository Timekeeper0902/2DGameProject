using System;
using System.Collections.Generic;
using UnityEngine;

namespace Timekeeper
{
    public class AudioSetting : MonoBehaviour
    {
        private static AudioSetting _instance;

        public static AudioSetting Instance => _instance;
        //[SerializeField] private AudioSource[] _audioSource;
        [SerializeField] private List<AudioSource> _audioSources = new List<AudioSource>();

        private AudioSetting(){}

        private void Awake()
        {
            _instance = this;
            ChangeValue(GameDataManager.Instance._musicData.musicValue);
            ChangeOpen(GameDataManager.Instance._musicData.isOpenBk);
        }

        /// <summary>
        /// 添加AudioSource到List中
        /// </summary>
        /// <param name="source"></param>
        public void AddAudioSource(AudioSource source)
        {
            _audioSources.Add(source);
        }

        /// <summary>
        /// 改变背景音乐大小
        /// </summary>
        /// <param name="value"></param>
        public void ChangeValue(float value)
        {
            foreach (var VARIABLE in _audioSources)
            {
                VARIABLE.volume = value;
            }
            //_audioSources.volume = value;
        }

        /// <summary>
        /// 是否静音背景音乐
        /// </summary>
        /// <param name="isOpen"></param>
        public void ChangeOpen(bool isOpen)
        {
            foreach (var VARIABLE in _audioSources)
            {
                VARIABLE.mute = !isOpen;
            }
            //_audioSources.mute = !isOpen;
        }
    }
}