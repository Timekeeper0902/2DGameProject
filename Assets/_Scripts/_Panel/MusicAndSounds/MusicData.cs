using UnityEngine;

namespace Timekeeper
{
    public class MusicData
    {
        public bool isOpenMusic;
        public bool isOpenAudio;

        public float musicValue;
        public float audioValue;
        
        //加一个时候是第一次加载游戏的标识
        public bool notFirstLoad;
    }
}