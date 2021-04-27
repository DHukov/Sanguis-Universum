using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Health;
    public int Stamina;
    public bool key1;
    public float[] position;
    //VectorValue savePos;
    //Vector3 PlayerPosition;
    public PlayerData(Player_Stats_Equipment player)
    {
        Health = player.Health;
        Stamina = player.Stamina;
        key1 = player.key1;

        /*
        PlayerPosition.x = savePos.Pos[0];
        PlayerPosition.y = savePos.Pos[0];
        PlayerPosition.z = savePos.Pos[0];

        */
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        
    }
}
