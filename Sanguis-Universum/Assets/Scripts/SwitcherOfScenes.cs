using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SwitcherOfScenes : MonoBehaviour
{

   // [SerializeField] public Object[] mySceneAssets;
    [SerializeField] private string m_SceneName = "";
    private Scene PrevScene;

    public KeyCode Key;
    public float downTime = 0f, upTime = 0f, pressTime = 3f;
    public float countDown = 1.0f;
    public bool ready = false;

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
            DestroyGameObject();
            Debug.Log("Is working after 2 seconds");
        }

        //Store the old scene.
        PrevScene = SceneManager.GetActiveScene();

        Debug.Log("Trigger is working");
        //StartCoroutine(ExampleCoroutine());
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
        Debug.Log("Game object has destroy");
    }

    IEnumerator LoadScene()
    {
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync(m_SceneName);
        while (!AsyncLoad.isDone)
        {
            yield return null;
        }
    }
}
