using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpened;

    public void IsUsed(GameObject obj)
    {
        if (!isOpened)
        {
            Player_Stats_Equipment manager = obj.GetComponent<Player_Stats_Equipment>();
            if (manager.key1)
            {
                isOpened = true;
                manager.useKey1();
            }
        }
    }
}
