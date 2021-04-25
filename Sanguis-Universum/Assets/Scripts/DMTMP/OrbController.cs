using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    public bool isOpened;

    public void IsUsed(GameObject obj)
    {
        if (!isOpened){
            PlayerManager manager = obj.GetComponent<PlayerManager>();
            if (manager.keys > 0)
            {
                isOpened = true;
                manager.useKey();
                Debug.Log("Dor has been opened");
                Debug.Log("Keys: " + manager.keys);
            }
        }
    }
}
