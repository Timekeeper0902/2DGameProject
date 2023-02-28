using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Timekeeper
{
    public class LoadManager : Singleton<LoadManager>
    {
        public GameObject LoadScreen;
        public Text text;

        public void LoadNextLevel()
        {
            StartCoroutine(Loadlevel());
        }

        IEnumerator Loadlevel()
        {
            LoadScreen.SetActive(true);
            AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            operation.allowSceneActivation = true;
            yield return null;
        }
    }
}