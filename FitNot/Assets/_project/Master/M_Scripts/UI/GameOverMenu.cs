using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Youssef;

namespace AyaOmar
{
    public class GameOverMenu : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 1f;
            AudioManager.Instance.Play2DSfx("game over");
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
