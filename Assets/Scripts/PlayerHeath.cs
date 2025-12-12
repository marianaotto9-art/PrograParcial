using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHeath : MonoBehaviour
{
    public int maxHearts = 5;
    public int currentHearts;

    public GameObject[] hearts;
    void Start()
    {
        currentHearts = maxHearts;

        hearts = GameObject.FindGameObjectsWithTag("Heart");
        hearts = hearts.OrderBy(h => h.name).ToArray();

        UpdateHeartsUI();
    }

    public void TakeDamage(int amount)
    {
        currentHearts -= amount;
        if (currentHearts < 0) currentHearts = 0;

        UpdateHeartsUI();

        if (currentHearts == 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHearts += amount;
        if (currentHearts > maxHearts) currentHearts = maxHearts;

        UpdateHeartsUI();
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHearts) hearts[i].SetActive(true);
            else hearts[i].SetActive(false);

        }
    }

    private void Die()
    {

        SceneManager.LoadScene("MenuDied");

    }

    
}

