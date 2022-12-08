using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timekeeper
{
    public class Parallax : MonoBehaviour
    {
        public Camera cam;
        public Transform player;

        private Vector2 _startPos;
        private float _startZ;//z轴坐标

        private Vector2 Travel => (Vector2)cam.transform.position - _startPos;//摄像机到视差图片的距离

        private float DistanceFromPlayer => transform.position.z - player.position.z;//视差图片到player的距离
        //判断图片在player前还是后，减去或加上距离
        private float ClippingPlane => (cam.transform.position.z +
                                        (DistanceFromPlayer > 0 ? cam.farClipPlane : cam.nearClipPlane));

        private float ParallaxFactor => Mathf.Abs(DistanceFromPlayer) / ClippingPlane;

        public void Start()
        {
            var position = transform.position;
            _startPos = position;
            _startZ = position.z;
        }

        public void Update()
        {
            var newPos = _startPos + Travel * ParallaxFactor;
            transform.position = new Vector3(newPos.x, newPos.y, _startZ);
        }
    }
}
