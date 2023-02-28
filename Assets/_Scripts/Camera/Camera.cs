using System;
using Cinemachine;
using UnityEngine;

namespace Timekeeper._Scripts.Camera
{
    public class Camera : MonoBehaviour
    {
        public CinemachineVirtualCamera playerCamera;

        private void Awake()
        {
            playerCamera = GetComponentInChildren<CinemachineVirtualCamera>();
            playerCamera.Follow = GameObject.FindWithTag("Player").transform;
        }
    }
}