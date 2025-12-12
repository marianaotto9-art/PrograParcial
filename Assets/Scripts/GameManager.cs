using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int enemigosRestantes = 8;
    private TextMeshProUGUI counterText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        GameObject textObj = GameObject.FindGameObjectWithTag("EnemyCounter");
        if (textObj != null) counterText = textObj.GetComponent<TextMeshProUGUI>();

        UpdateUI();
    }

    public void EnemyKilled()
    {
        enemigosRestantes--;

        UpdateUI();

        if (enemigosRestantes <= 0)
        {
            Victory();
        }
    }

    private void UpdateUI()
    {
        if (counterText != null) counterText.text = enemigosRestantes.ToString();
    }

    private void Victory()
    {
        SceneManager.LoadScene("MenuVictory");
    }
}
