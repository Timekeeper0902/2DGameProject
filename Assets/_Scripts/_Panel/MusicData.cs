using UnityEngine;

namespace Timekeeper
{
    public class MusicData
    {
        public bool isOpenBk;
        public bool isOpenSound;

        public float musicValue;
        public float soundValue;
        
        //加一个时候是第一次加载游戏的标识
        public bool notFirstLoad;
    }
}