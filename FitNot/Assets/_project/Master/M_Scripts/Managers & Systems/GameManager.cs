using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Youssef;

namespace AyaOmar
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("list of refrences player index 0,melee mummy index 1,ranged mummy index 2")]
        public List<GameObject> RefList = new List<GameObject>();

        [Header("index 0 melee, index 1 ranged")]
        public List<RuntimeAnimatorController> PlayerAnimatorStates = new List<RuntimeAnimatorController>();

        
        private void Awake()
        {
            base.RegisterSingleton();
        }
        public GameObject GetPlayerRef()
        {
            return RefList[0];
        }
        public GameObject GetMeleeMummyRef()
        {
            return RefList[1];
        }
        public GameObject GetRangedMummyRef()
        {
            return RefList[2];
        }
        public GameObject GetRangedMummySpitPosRef()
        {
            GameObject spitPos;
            spitPos = GameObject.FindWithTag("SpitPos");

            return spitPos;
        }
        public RuntimeAnimatorController GetMeleePlayerAnimator()
        {
            return PlayerAnimatorStates[0];
        }
        public RuntimeAnimatorController GetRangedPlayerAnimator()
        {
            return PlayerAnimatorStates[1];
        }
        
        private void Update()
        {
            CloseGame();
        }
        private void CloseGame()
        {
            //HealthManager playerHealth = RefList[0].GetComponent<HealthManager>();
            if (RefList[0] == null)
            {
                Time.timeScale = 0;
                SceneManager.LoadScene(2);
            }
        }
    }
}
