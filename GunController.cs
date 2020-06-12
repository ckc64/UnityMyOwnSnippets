using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject currentGun;
    public GameObject gunHolder;

    void Start()
    {
        
        Instantiate(currentGun,new Vector3(transform.position.x,transform.position.y, transform.position.z),Quaternion.identity,gunHolder.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
