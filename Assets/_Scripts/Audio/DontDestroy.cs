using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timekeeper
{
    public class DontDestroy : MonoBehaviour
    {
        void Update()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
