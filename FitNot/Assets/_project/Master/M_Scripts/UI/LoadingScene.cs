using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace AyaOmar
{
    public class LoadingScene : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Slider loadingBarFill;

        private void Start()
        {
            LoadingSceneFun(1);
        }
        public void LoadingSceneFun(int sceneIndex)
        {
            StartCoroutine(LoadingScreenAsyn(sceneIndex));
        }
        IEnumerator LoadingScreenAsyn(int sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
            loadingScreen.SetActive(true);
            while (!operation.isDone)
            {
                float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
                loadingBarFill.value = progressValue;
                yield return null;
            }
        }
    }
}
