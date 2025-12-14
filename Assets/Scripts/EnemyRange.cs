using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public int life;
    public float speed;
    public int damage;
    public bool died;
    public float speedRotation;
    public Transform player;
    public float visionRange;
    public Vector3[] waipoints;
    public bool onSight;
    public int indice;
    public float fireRate; //siempre vale 2
    public float nextFireRate; //se va sumando el tiempo y cuando llega a 2, le asignamos 0
    public GameObject bullet;
    public Transform bulletSpawnerEnemy;

    // Start is called before the first frame update
    void Start()
    {
        died = false;
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MovEnemiy();
    }

    public void TakeDamage(int damage)
    {
        life = life - damage;
        if (life <= 0 && !died)
        {
            died = true;
            Destroy(gameObject);

        }

    }
    

    public void MovEnemiy()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) < visionRange)
            {
                onSight = true;
            }
            else
            {
                onSight = false;
            }
            if (onSight == true)
            {
                if (nextFireRate >= fireRate)
                {
                    Instantiate(bullet, bulletSpawnerEnemy.position, bulletSpawnerEnemy.rotation);
                    nextFireRate = 0;
                }
                else
                {
                    nextFireRate += Time.deltaTime;
                }
                LockAt(player.position);
            }
            else
            {
                LockAt(waipoints[indice]);
                nextFireRate = 0;
                if (Vector2.Distance(transform.position, waipoints[indice]) < 0.2f)
                {
                    indice++;
                    if (indice >= waipoints.Length)
                    {
                        indice = 0;
                    }
                }
                transform.position += transform.right * speed * Time.deltaTime;
            }
        }
    }
    public void LockAt(Vector3 posicionAMirar)
    {
        Vector3 direccion = posicionAMirar - transform.position;
        direccion.Normalize();
        ////Rotacion
        float angle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg; //Obtengo desde yo estoy parado y hasta donde yo tengo que mirar (angulo)
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward); //el enemigo estaria mirando sobre el eje X y al rotar cambia, por eso el -90° 
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedRotation * Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach (var item in waipoints)
        {

            Gizmos.DrawSphere(item, 0.4f);
        }
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
    

}
