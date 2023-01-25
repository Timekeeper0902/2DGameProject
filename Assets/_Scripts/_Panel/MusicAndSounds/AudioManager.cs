using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timekeeper
{
    public class AudioManager : Singleton<AudioManager>
    {
        private AudioSource _playerJumpSource;
        private AudioSource _playerMoveSource;
        
        private AudioSource _EnemyHitSource;
        private AudioSource _errowShootSource;

        /// <summary>
        /// 玩家移动音效
        /// </summary>
        /// <param name="clips"></param>
        public void PlayerMovePlay(AudioClip[] clips)
        {
            if (_playerMoveSource == null)
            {
                _playerMoveSource = gameObject.AddComponent<AudioSource>();
                AudioSetting.Instance.AddAudioSource(_playerMoveSource);
            }
            int index = Random.Range(0, clips.Length);
            _playerMoveSource.clip = clips[index];
            _playerMoveSource.volume = GameDataManager.Instance._musicData.audioValue;
            _playerMoveSource.mute = !GameDataManager.Instance._musicData.isOpenAudio;
            _playerMoveSource.Play();
        }
        
        /// <summary>
        /// 玩家跳跃音效
        /// </summary>
        /// <param name="clip"></param>
        public void PlayerJumpPlay(AudioClip clip)
        {
            if (_playerJumpSource == null)
            {
                _playerJumpSource = gameObject.AddComponent<AudioSource>();
                AudioSetting.Instance.AddAudioSource(_playerJumpSource);
            }
            _playerJumpSource.clip = clip;
            _playerJumpSource.volume = GameDataManager.Instance._musicData.audioValue;
            _playerJumpSource.mute = !GameDataManager.Instance._musicData.isOpenAudio;
            _playerJumpSource.Play();
        }
        
        /// <summary>
        /// 敌人受伤
        /// </summary>
        /// <param name="clip"></param>
        public void EnemyHitPlay(AudioClip clip)
        {
            if (_EnemyHitSource == null)
            {
                _EnemyHitSource = gameObject.AddComponent<AudioSource>();
                AudioSetting.Instance.AddAudioSource(_EnemyHitSource);
            }
            _EnemyHitSource.clip = clip;
            _EnemyHitSource.volume = GameDataManager.Instance._musicData.audioValue;
            _EnemyHitSource.mute = !GameDataManager.Instance._musicData.isOpenAudio;
            _EnemyHitSource.Play();
        }
        
        /// <summary>
        /// 弓箭射出
        /// </summary>
        /// <param name="clip"></param>
        public void ArrowShootPlay(AudioClip clip)
        {
            if (_errowShootSource == null)
            {
                _errowShootSource = gameObject.AddComponent<AudioSource>();
                AudioSetting.Instance.AddAudioSource(_errowShootSource);
            }
            _errowShootSource.clip = clip;
            _errowShootSource.volume = GameDataManager.Instance._musicData.audioValue;
            _errowShootSource.mute = !GameDataManager.Instance._musicData.isOpenAudio;
            _errowShootSource.Play();
        }
        
    }
}
