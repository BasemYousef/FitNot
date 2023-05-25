using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AyaOmar
{
    public class MainMenu : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 1f;
        }
        public void StartGame(int index)
        {
            SceneManager.LoadScene(index);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
        
    }
}
