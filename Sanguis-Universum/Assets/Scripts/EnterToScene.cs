using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToScene : MonoBehaviour
{
    //public GameObject coll;
    // public Collider2D coll;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Collider2D");
    }
    private void OnTriggerEnter2D(Collision2D collision)
    {
        Debug.Log("sadw");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("sadw");
    }
    private void OnCollisionEnter2D(Collider2D collision)
    {
        Debug.Log("sadw");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Q was press");
        }
    }
    /* // Use this for initialization
     void Start()
     {
         //Check if the isTrigger option on th Collider2D is set to true or false
         if (coll.isTrigger)
         {
             Debug.Log("This Collider2D can be triggered");
         }
         else if (!coll.isTrigger)
         {
             Debug.Log("This Collider2D cannot be triggered");
         }
     }

    */
}
