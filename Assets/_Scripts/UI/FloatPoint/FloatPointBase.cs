using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timekeeper
{
    public class FloatPointBase : MonoBehaviour
    {
        public float distoryTime;
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject,distoryTime);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
