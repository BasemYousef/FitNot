using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AyaOmar
{
    public class GameOverMenu : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 1f;
        }
        public void RePlay(int index)
        {
            SceneManager.LoadScene(index);
        }
        public void Back(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}
