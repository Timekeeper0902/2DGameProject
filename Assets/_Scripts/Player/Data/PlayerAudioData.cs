using Sirenix.OdinInspector;
using UnityEngine;

namespace Timekeeper.Player.Data
{
    [CreateAssetMenu(fileName = "音频数据", menuName = "数据/玩家数据/音频数据", order = 0)]
    [InlineEditor]
    public class PlayerAudioData : ScriptableObject
    {
        public AudioClip[] moveClips;
        public AudioClip jumpClip;
    }
}