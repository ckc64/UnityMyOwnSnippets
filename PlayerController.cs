using System.Collections;
using System.Collections.Generic;

using Unity.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 40f;
    public Animator anim;
    public GameObject bullet;
    public GameObject bulletFall;
    public Transform gunEndPoint;
   //public Vector3 lastMoveDirection;

    public Shake shake;
    public Joystick joystick;
    Vector2 move;
    // Update is called once per frame
    public Rigidbody2D rigid;

    public AudioSource audio;
    void Update()
    {
        //DefaultMovement();

        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        float moveZ = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, -moveZ);
        Movement();
    }

    void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + move * playerSpeed * Time.fixedDeltaTime);
    }
    void Movement()
    {
        float moveX = 0f;
        float moveY = 0f;

        
       

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
           
           
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
           
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
          
        }
        transform.position += new Vector3(moveX, moveY) * playerSpeed * Time.deltaTime;
        bool isIdle = moveX == 0 && moveY == 0;
        if (!isIdle)
        {
            anim.SetTrigger("Move");
        }
        else
        {
            anim.SetTrigger("Idle");
        }
        

        
        
        //face mouse position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Debug.Log(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.right = direction;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            //anim.SetTrigger("Shoot");
            //Transform bulletTransform = Instantiate(bullet,gunEndPoint.transform.position,Quaternion.identity);
            //Vector3 shootDirection = (mousePosition - gunEndPoint.transform.position).normalized;
            //bulletTransform.GetComponent<Bullet>().Setup(shootDirection);
            float bulletForce = 20f;
            GameObject bulletTransform = Instantiate(bullet, gunEndPoint.transform.position, gunEndPoint.rotation);
            Rigidbody2D rb = bulletTransform.GetComponent<Rigidbody2D>();
           
            rb.AddForce(gunEndPoint.up * bulletForce, ForceMode2D.Impulse);

            shake.CamShake(5f, 0.1f);
            audio.PlayOneShot(audio.clip);
            GameObject bulletFallRigid = Instantiate(bulletFall, gunEndPoint.transform.position, gunEndPoint.rotation);
            Rigidbody2D rb2 = bulletFallRigid.GetComponent<Rigidbody2D>();
            rb2.AddForce(bulletFallRigid.transform.right * -5f, ForceMode2D.Impulse);
            
            rb2.AddTorque(60f, ForceMode2D.Impulse);
            Destroy(bulletFallRigid, 0.5f);
        }
    }


  

}
