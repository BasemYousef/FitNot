using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using AyaOmar;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] string[] sentences;
    [SerializeField] GameObject enemyPrefab1;
    [SerializeField] GameObject enemyPrefab2;
    [SerializeField] GameObject[] arrowIndicators;
    [SerializeField] GameObject gunPrefab;
    [SerializeField] GameObject[] managersPrefabs;

    private bool isKeyPressed = false; 
    private float keyPressTime = 0f; 
    private int index;
    private int step;
    private bool tutorialSkipped = false;

    private void Start()
    {
        StartCoroutine(Type());
    }
    private void Update()
    {
        if (!tutorialSkipped)
        {
            NextSentence();

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                SkipTutorial();
            }
        }
    }
    IEnumerator Type()
    {
        textDisplay.text = sentences[index];
        yield return null;
    }

    public void NextSentence()
    {
        switch (step)
        {
            case 0:
                // Welcome Message for the player 
                if (Keyboard.current.enterKey.wasPressedThisFrame)
                {
                    index++;
                    StartCoroutine(Type());
                    step++;
                }
                break;
            case 1:
                // Check if a key is pressed using the new input system
                if (Keyboard.current.wKey.isPressed || Keyboard.current.aKey.isPressed ||
                    Keyboard.current.sKey.isPressed || Keyboard.current.dKey.isPressed)
                {
                    isKeyPressed = true;
                    keyPressTime += Time.deltaTime;

                    // Check if the key has been pressed for more than 2 seconds
                    if (isKeyPressed && keyPressTime >= 2f)
                    {
                        index++;
                        StartCoroutine(Type());
                        step++;
                    }
                }
                else
                {
                    isKeyPressed = false;
                    keyPressTime = 0f;
                }
                break;
                case 2:
                // Check if player pressed Enter button then the Hunger gauge description will show
                if (arrowIndicators[0] != null)
                {
                    arrowIndicators[0].SetActive(true);
                }
                if (Keyboard.current.enterKey.wasPressedThisFrame)
                {
                   
                    index++;
                    StartCoroutine(Type());
                    step++;
                    arrowIndicators[0].SetActive(false);
                }
                break;
            case 3:
                // Food Arrow Indicators
                if (arrowIndicators[2] != null && arrowIndicators[3] != null && arrowIndicators[4] != null)
                {
                    arrowIndicators[2].SetActive(true);
                    arrowIndicators[3].SetActive(true);
                    arrowIndicators[4].SetActive(true); 
                }
                if (Keyboard.current.enterKey.wasPressedThisFrame)
                {
                    index++;
                    StartCoroutine(Type());
                    step++;
                    arrowIndicators[2].SetActive(false);
                    arrowIndicators[3].SetActive(false);
                    arrowIndicators[4].SetActive(false);
                }
                break;
            
            case 4:
                // Check if player pressed Enter button then the day gauge description will show
                if (arrowIndicators[1] != null)
                {
                    arrowIndicators[1].SetActive(true);
                }
                if (Keyboard.current.enterKey.wasPressedThisFrame)
                {
                   
                    index++;
                    StartCoroutine(Type());
                    step++;
                    arrowIndicators[1].SetActive(false);
                }
                break;
            case 5:
                 // Check if enemyPrefab1 is killed 
                if (enemyPrefab1 != null)
                {
                   enemyPrefab1.SetActive(true); 
                   if (!enemyPrefab1.activeSelf) 
                   {
                      index++;
                      StartCoroutine(Type());
                      step++;
                      break; // Added break statement to exit the case 4
                   }
                }
                else // If enemyPrefab1 is null, go to case 5
                {
                   index++;
                   StartCoroutine(Type());
                   step++;
                   break;
                 }
                   break; 

            case 6:
                // Check if Q button is pressed to open the inventory using the new input system
                
                if (Keyboard.current.qKey.wasPressedThisFrame)
                {
                    index++;
                    StartCoroutine(Type());
                    step++;
                }
                break;
            case 7:

                if (Keyboard.current.enterKey.wasPressedThisFrame)
                {
                    index++;
                    StartCoroutine(Type());
                    step++;
                }
                break;
            case 8:
                if (gunPrefab != null)
                {
                    gunPrefab.SetActive(true);
                    if (!gunPrefab.activeSelf)
                    {
                        index++;
                        StartCoroutine(Type());
                        step++;
                        break; 
                    }
                }
                else 
                {
                    index++;
                    StartCoroutine(Type());
                    step++;
                    break;
                }
                break;

            case 9:
                if (enemyPrefab2 != null)
                {
                    enemyPrefab2.SetActive(true);
                    if (Keyboard.current.enterKey.wasPressedThisFrame)
                    {

                        index++;
                        StartCoroutine(Type());
                        step++;
                    }
                    
                }
                break;
          
            default:
                // Reached the end of the dialogue
                
                managersPrefabs[0].SetActive(false);
                managersPrefabs[1].SetActive(true);
                managersPrefabs[2].SetActive(true);
                textDisplay.text = "";
                break;
        }
       
    }
    public void SkipTutorial()
    {
        managersPrefabs[0].SetActive(false);
        managersPrefabs[1].SetActive(true);
        managersPrefabs[2].SetActive(true);
        tutorialSkipped = true;
        textDisplay.text = "";
    }
    
}
