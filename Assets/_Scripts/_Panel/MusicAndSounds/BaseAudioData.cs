using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Timekeeper._Panel
{
    [CreateAssetMenu(fileName = "音频数据", menuName = "数据/玩家数据/音频数据", order = 0)]
    [InlineEditor]
    public class BaseAudioData : ScriptableObject
    {
        protected const string PlayerBaseSeff= "玩家的音效";
        protected const string EnemyBaseSeff= "敌人的音效";
        [FormerlySerializedAs("moveClips")] [FoldoutGroup("@PlayerBaseSeff"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
        public AudioClip[] p_moveClips;
        [FormerlySerializedAs("jumpClip")] [FoldoutGroup("@PlayerBaseSeff"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
        public AudioClip p_jumpClip;



        [FoldoutGroup("@EnemyBaseSeff"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
        public AudioClip e_hitClip;
        [FoldoutGroup("@EnemyBaseSeff"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
        public AudioClip e_attackClip;
        [FoldoutGroup("@EnemyBaseSeff"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
        public AudioClip e_rangeClip;

    }
}