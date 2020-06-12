using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Idle,
        Shoot,

    }
    public float health;
    private State state;
    private float playerToEnemyRange = 10f;
    public Transform playerAsTarget;
    public Transform gundEndPoint;
    public GameObject bulletPf;
    private float fireRate = 0.5f;
    private float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                //Debug.Log("Enemy Idle");
                break;
            case State.Shoot:
                //Debug.Log("Enemy Shoot");

                if(Time.time > nextFire)
                {

                    nextFire = Time.time + fireRate;
                    GameObject bulletTransform = Instantiate(bulletPf, gundEndPoint.transform.position, gundEndPoint.transform.rotation);
                    Rigidbody2D rb = bulletTransform.GetComponent<Rigidbody2D>();

                    rb.AddForce(gundEndPoint.transform.up * 20f, ForceMode2D.Impulse);

                }
                
                break;
        }
       
        if(Vector3.Distance(transform.position,playerAsTarget.position) < playerToEnemyRange)
        {
           
                Vector2 lookPosition = playerAsTarget.position - transform.position;
                float angle = Mathf.Atan2(lookPosition.y, lookPosition.x) * Mathf.Rad2Deg;
                //lookPosition.y = 0.0f;
                //lookPosition.x = 0.0f;
                Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5.5f *  Time.deltaTime);

            
            if(Vector3.Distance(transform.position, playerAsTarget.position) < 7.0f)
            {

                state = State.Shoot;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, playerAsTarget.position + Vector3.up, 3f * Time.deltaTime);
            }
            
            if(health == 0)
            {
                Destroy(gameObject);
            }
            
            //StartCoroutine(ShotDelay());
        }else
        {
            state = State.Idle;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
    }
}
