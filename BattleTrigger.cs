using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject.name != null)
        {
            Debug.Log("Player Entered");
        }
    }
}
