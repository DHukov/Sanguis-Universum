using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class EnterToScene : MonoBehaviour
{
    public Scene  _scene;
    private Scene PrevScene;
    
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
   //     StartCoroutine(ExampleCoroutine());
    }
 
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger is working");
        StartCoroutine(ExampleCoroutine());

        StartCoroutine(LoadScene());

        //Store the old scene.
        PrevScene = SceneManager.GetActiveScene();
 

        //StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync("DH_Scene");
        while (!AsyncLoad.isDone)
        {
            yield return null;
        }
        //yield return null;
    }
}
