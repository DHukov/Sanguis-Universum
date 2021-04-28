using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Health = 4;
    public int Stamina = 8;

    public bool key1;
    public bool key1Used;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        key1 = data.key1;
        Health = data.Health;
        Stamina = data.Stamina;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
    }
    public void PickUpKey1()
    {
        if (!key1)
        {
            key1 = true;
            Debug.Log("I found a key of the first foor!");
        }
    }
    public void useKey1()
    {
        if (!key1Used)
        {
            Debug.Log("Door has been opened...");
        }
    }
}