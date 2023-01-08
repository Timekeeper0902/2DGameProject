using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timekeeper
{
    public class AudioManager : Singleton<AudioManager>
    {
        private AudioSource _playerJumpSource;
        private AudioSource _playerMoveSource;


        public void PlayerMovePlay(AudioClip[] clips)
        {
            if (_playerMoveSource == null)
            {
                _playerMoveSource = gameObject.AddComponent<AudioSource>();
                AudioSetting.Instance.AddAudioSource(_playerMoveSource);
            }
            int index = Random.Range(0, clips.Length);
            _playerMoveSource.clip = clips[index];
            _playerMoveSource.Play();
        }
        
        public void PlayerJumpPlay(AudioClip clip)
        {
            if (_playerJumpSource == null)
            {
                _playerJumpSource = gameObject.AddComponent<AudioSource>();
                AudioSetting.Instance.AddAudioSource(_playerJumpSource);
            }
            _playerJumpSource.clip = clip;
            _playerJumpSource.Play();
        }
        
        
        
    }
}
