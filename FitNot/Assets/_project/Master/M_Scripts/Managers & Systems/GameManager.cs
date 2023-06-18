using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Youssef;

namespace AyaOmar
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("list of refrences player index 0,melee mummy index 1,ranged mummy index 2")]
        public List<GameObject> RefList = new List<GameObject>();
        public List<LootBoxSpawner>managerList = new List<LootBoxSpawner>();
        [Header("index 0 melee, index 1 ranged")]
        public List<RuntimeAnimatorController> PlayerAnimatorStates = new List<RuntimeAnimatorController>();

        public Slider slider;

        [Header("text appear when item is used")]
        [SerializeField] private TMP_Text minus_Text;
        private void Awake()
        {
            base.RegisterSingleton();
        }
        public GameObject GetPlayerRef()
        {
            if (RefList[0] != null)
            {
                return RefList[0];
            }
            else { return null; }
                
        }
        public GameObject GetMeleeMummyRef()
        {
            if (RefList[1] != null)
            {
                return RefList[1];
            }
            else { return null; }
        }
        public GameObject GetRangedMummyRef()
        {
            if (RefList[2] != null)
            {
                return RefList[2];
            }
            else { return null; }
        }
        public GameObject GetAimObjectRef()
        {
            if (RefList[3] != null)
            {
                return RefList[3];
            }
            else { return null; }
        }
        public LootBoxSpawner GetLootBoxSpawnerRef()
        {
            if (managerList[0] != null)
            {
                return managerList[0];
            }
            else { return null; }
        }
        public GameObject GetRangedMummySpitPosRef()
        {
            GameObject spitPos;
            spitPos = GameObject.FindWithTag("SpitPos");

            return spitPos;
        }
        public RuntimeAnimatorController GetMeleePlayerAnimator()
        {
            if (PlayerAnimatorStates[0] != null)
            {
                return PlayerAnimatorStates[0];
            }
            else { return null; }
        }
        public RuntimeAnimatorController GetRangedPlayerAnimator()
        {
            if (PlayerAnimatorStates[1] != null)
            {
                return PlayerAnimatorStates[1];
            }
            else { return null; }
        }
        public Slider GetHungerSlider() 
        {
            return slider;
        }
        public TMP_Text GetMinusTxt()
        {
            return minus_Text;
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
