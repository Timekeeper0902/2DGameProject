using UnityEngine;

namespace Timekeeper.Intermediaries
{
    public class AudioToAudio : MonoBehaviour
    {
        public PlayerMoveState moveState;

        private void MoveAudioPlay()
        {
            moveState.MoveAudioPlay();
        }
    }
}