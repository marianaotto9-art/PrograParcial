using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject sword; 
    public float attackDuration = 0.2f; 
    private bool isAttacking = false;
    public int maxHearts = 5;
    public int currentHearts;

    public GameObject[] hearts;


    private Vector2 lastMoveDirection = Vector2.down;

    void Start()
    {
        currentHearts = maxHearts;

        hearts = GameObject.FindGameObjectsWithTag("Heart");
        hearts = hearts.OrderBy(h => h.name).ToArray();

        UpdateHeartsUI();
    }

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Ataque(horizontal, vertical);
       
    }

    private void Ataque(float horizontal, float vertical)
    {
        Vector2 moveDir = new Vector2(horizontal, vertical);

        if (moveDir != Vector2.zero)
            lastMoveDirection = moveDir.normalized;


        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private System.Collections.IEnumerator Attack()
    {
        isAttacking = true;
        sword.SetActive(true);

       
        Vector3 swordPos = Vector3.zero;
        float rotation = 0f;

        if (lastMoveDirection == Vector2.up)
        {
            swordPos = new Vector3(0, 1, 0);
            rotation = 0f;
        }
        else if (lastMoveDirection == Vector2.down)
        {
            swordPos = new Vector3(0, -1, 0);
            rotation = 180f;
        }
        else if (lastMoveDirection == Vector2.left)
        {
            swordPos = new Vector3(-1, 0, 0);
            rotation = 90f;
        }
        else if (lastMoveDirection == Vector2.right)
        {
            swordPos = new Vector3(1, 0, 0);
            rotation = -90f;
        }

        sword.transform.localPosition = swordPos;
        sword.transform.localEulerAngles = new Vector3(0, 0, rotation);

        yield return new WaitForSeconds(attackDuration);

        sword.SetActive(false);
        isAttacking = false;
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