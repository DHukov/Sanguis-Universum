using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SwitcherOfScenes : MonoBehaviour
{

   // [SerializeField] public Object[] mySceneAssets;
    [SerializeField] private string m_SceneName = "";
    Scene PrevScene;
    public KeyCode Key;
    public float downTime = 0f, upTime = 0f, pressTime = 3f;
    public float countDown = 1.0f;
    public bool ready = false;

    //erializeField] private GameObject playerPrefab = null;
    // [SerializeField] public GameObject playerPrefab;
    public GameObject startPrefab;
    public GameObject deletePrefab;
    Vector2 m_NewPosition;

    void InstantiatePrefabHero()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(startPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(Key) && ready == false)
        {
            downTime = Time.time;
            pressTime = downTime + countDown;
            ready = true;

        }
        if (Input.GetKeyUp(Key))
        {
            ready = false;

        }
        if (Time.time >= pressTime && ready == true)
        {
            ready = false;
            StartCoroutine(LoadScene());
            Debug.Log("Is working after 2 seconds");
        }

        //Store the old scene.
        PrevScene = SceneManager.GetActiveScene();

        Debug.Log("Trigger is working");
    }
    
    void DestroyGameObject()
    {
        Destroy(deletePrefab);
        Debug.Log(deletePrefab + "Is destroy");
    }
   
    IEnumerator LoadScene()
    {
       // m_NewPosition =  Vector2.zero;
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync(m_SceneName);
        InstantiatePrefabHero();
        //startPrefab.transform.position = m_NewPosition;
        DestroyGameObject();

        while (!AsyncLoad.isDone)
        {            
            yield return null;
        }
    }
}
