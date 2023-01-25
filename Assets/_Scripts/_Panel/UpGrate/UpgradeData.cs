using Sirenix.OdinInspector;
using UnityEngine;

namespace Timekeeper._Panel.UpGrate
{
    [CreateAssetMenu(fileName = "UpgradeData", menuName = "数据/玩家数据/等级数据", order = 0)]
    [InlineEditor]
    public class UpgradeData : ScriptableObject
    {
        [SerializeField] private ExperienceData[] experienceData;
        
        public ExperienceData[] ExperienceData
        {
            get => experienceData;
            private set => experienceData = value;
        }

    }

    [System.Serializable]
    public struct ExperienceData
    {
        public int nextLevelExp;
        public int targetLevel;
    }
}