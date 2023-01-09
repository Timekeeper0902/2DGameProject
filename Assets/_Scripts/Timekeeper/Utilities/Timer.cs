using System;
using UnityEngine;

namespace Timekeeper.Utilities
{
    public class Timer
    {
        public event Action OnTimerDone;
        
        public  float startTime;
        private float duration;
        private float targetTime;

        private bool isActive;
        
        public Timer(float duration)
        {
            this.duration = duration;
        }

        public void StartTimer()
        {
            startTime = Time.time;
            targetTime = startTime + duration;
            isActive = true;
        }

        public void StopTimer()
        {
            isActive = false;
            Debug.Log("TimerStop");
        }

        public void Tick()
        {
            if(!isActive) return;

            Debug.Log(targetTime);
            Debug.Log(Time.time);
            if (Time.time >= targetTime)
            {
                
                OnTimerDone?.Invoke();
                StopTimer();
            }
        }
    }
}