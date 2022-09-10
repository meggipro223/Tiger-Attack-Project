using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    public GameObject Losepanel, WinPanel;
    public Button restartButton;

    public int killedFoxes;
    public int totalFoxes;
    public int numberCounter;

    public Text counterText;

    private bool CheckIfThrowIsWorking;

    private void Awake()
    {
        InitializeVariables();
        restartButton.onClick.AddListener(() => RestartButton());
    }

    private void Update()
    {
        SettingUpIntegers();
    }

    void MakeInstace()
    {
        if (instance == null)
            instance = this;
    }

    void SettingUpIntegers()
    {
        if(killedFoxes == totalFoxes)
        {
            WinPanel.SetActive(true);
        }

        if (numberCounter == 0)
        {
            if (Player.instance.myBody.IsSleeping())
            {

                CheckIfThrowIsWorking = false;
                PlayerThrowerr.instance.isWorking = false;
                Losepanel.SetActive(true);
            }

            if (!Player.instance.myBody.IsSleeping())
            {
                CheckIfThrowIsWorking = false;
                PlayerThrowerr.instance.isWorking = false;
            }

        }

        if(numberCounter == 1 || numberCounter == 2 || numberCounter == 3
           || numberCounter == 4 || numberCounter == 5)
        {
            CheckIfThrowIsWorking = true;
            PlayerThrowerr.instance.isWorking = true;
        }
    }

    void InitializeVariables()
    {
        MakeInstace();
        CheckIfThrowIsWorking = true;
        numberCounter = 4;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Losepanel.SetActive(false);
    }

    public void CheckIfThrow()
    {
        if (CheckIfThrowIsWorking)
        {
            if(PlayerThrowerr.instance.Throw() == true)
            {
                numberCounter--;
                counterText.text = numberCounter.ToString();
            }
        }
    }
}
