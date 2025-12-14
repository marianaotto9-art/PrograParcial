using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void OpenControls()
    {
        SceneManager.LoadScene("MenuControls");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Saliste del juego");
    }

    public void LevelsMenu()
    {
        SceneManager.LoadScene("Levels");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
}
