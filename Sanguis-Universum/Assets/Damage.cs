using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Damage : MonoBehaviour
{
    public UnityEvent damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogError("you are in area ");
        damage.Invoke();
    }
}
