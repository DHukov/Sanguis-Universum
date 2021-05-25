using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int Health;
    public int Stamina;
    public bool key1;
    public float[] position;

    public Scene SceneIndex;

    public PlayerData(PlayerStats player)
    {
        Health = player.Health;
        Stamina = player.Stamina;
        key1 = player.key1;
        SceneIndex = SceneManager.GetActiveScene();
        Debug.Log(SceneIndex.buildIndex);

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }
}