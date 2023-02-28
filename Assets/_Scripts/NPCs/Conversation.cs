using System;
using UnityEngine;

namespace Timekeeper.NPCs
{
    [CreateAssetMenu(fileName = "Conversation", menuName = "数据/对话数据", order = 0)]
    public class Conversation : ScriptableObject
    {
        public Dialog[] dialogs;
    }

    [Serializable]
    public class Dialog
    {
        public string name;
        [TextArea] public string speak;
    }
}