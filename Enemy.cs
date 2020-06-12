using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject [] blood;
    public GameObject shotArea;
    private void Update()
    {
        //transform.position += new Vector3(Random.Range(1,10), 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collidedObject)
    {
        Instantiate(blood[Random.Range(0,blood.Length)], shotArea.transform.position , shotArea.transform.rotation);
        Debug.Log(blood);
        //Destroy(gameObject);
    }
}
