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

    public void WinMenu()
    {
        SceneManager.LoadScene("MenuVictory");
    }

    public void MenuDied()
    {
        SceneManager.LoadScene("MenuDied");
    }
}
