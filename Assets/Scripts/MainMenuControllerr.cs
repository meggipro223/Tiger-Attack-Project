using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllerr : MonoBehaviour {

	public void PlayBtn()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ExitBtn()
    {
        Application.Quit();
        print("We exit the game!");
    }
}
