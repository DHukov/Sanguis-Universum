using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int keys;

    public void PickUpKey()
    {
        keys++;
        Debug.Log("Keys: " + keys);
    }
    public void useKey()
    {
        keys--;
        Debug.Log("Keys: " + keys);
    }
}
