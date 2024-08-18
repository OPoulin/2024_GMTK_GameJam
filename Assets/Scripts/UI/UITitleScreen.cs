using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITitleScreen : MonoBehaviour
{

    public GameObject credits;
    public Button creditsButton;
    public Button creditsReturn;
    public Button Quit;
    public Button Play;

    public void ActivateCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("HomeStart");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
