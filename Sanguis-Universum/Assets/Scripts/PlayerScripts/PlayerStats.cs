using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerStats : MonoBehaviour
{
    public int Health = 4;
    public int Stamina = 8;

    public bool key1;
    public bool key1Used;

    public int SceneIndex;

    /*
    public void OnDisable()
    {
        Debug.Log("PrintOnDisable: script was disabled");
        SavePlayer();

    }
      
    public void OnEnable()
    {
        PlayerData data2 = SaveSystem.LoadPlayer();
        SceneIndex = data2.SceneIndex.buildIndex;
        Debug.Log("PrintOnEnable: script was enabled" + SceneIndex);
        SceneManager.LoadScene(SceneIndex);
        LoadPlayerStats();

    }
      
     */


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayerStats();
            LoadPlayerPosition();
            Debug.Log("L");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            
            SavePlayer();
            Debug.Log("K");

        }
    }
    
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayerStats()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        //key1 = data.key1;
        Health = data.Health;
        Stamina = data.Stamina;

        //SceneIndex = data.SceneIndex.buildIndex;
       // Debug.Log(SceneIndex);

    }
    public void LoadPlayerPosition()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
         
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