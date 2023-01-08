using UnityEngine;

namespace Timekeeper
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    var go = new GameObject(typeof(T).Name);
                    _instance = go.AddComponent<T>();
                }
                return _instance;
            }
        }
        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                GameObject.DontDestroyOnLoad(_instance.gameObject);
            }
            else
                GameObject.Destroy(_instance.gameObject);

        }
        
        public virtual void ShowMe()
        {
            this.gameObject.SetActive(true);
        }
    
        public virtual void HideMe()
        {
            this.gameObject.SetActive(false);
        }
    }

}