using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject MenuPausaUI;
    private bool isPaused = false;
    void Start()
    {
        MenuPausaUI.SetActive(false);
        Time.timeScale = 1f;
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pausa");
            if (isPaused)
                Continue();
            else
                Pause();
        }
    }

    public void Continue()
    {
        MenuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        MenuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
