using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SwitcherOfScenes : MonoBehaviour
{
    public Vector3 position;
    public VectorValue PlayerStorage;

    [SerializeField] string m_SceneName;
    public float spaceHoldingTime = 0;
    [SerializeField] float time;


    private bool HasPlayer;
    public KeyCode KeyToScene;

    public Animator anim;

    void Start()
    {
        //StartCoroutine(CountPressTimeCoroutine());
        anim = GetComponent<Animator>();
    }

    public void Update()
    {

        if (Input.GetKey(KeyToScene) && HasPlayer == true)
        {
            StartCoroutine(LoadScene());
        }
        else
        {

        }
       
        if (Input.GetKey(KeyToScene) == false || HasPlayer == false)
        {
            StopCoroutine(LoadScene());
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.CompareTag("Player"))
        {

            HasPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.CompareTag("Player"))
        {
            HasPlayer = false;
        }
    }
    /*

        Scene PrevScene;
    public KeyCode Key;
    public float downTime = 3f, upTime = 0f, pressTime = 0f;
    public float countDown = 1.0f;
    public bool ready = false;

      if (Input.GetKeyUp(KeyCode.Space))
      {
          StopCoroutine(Action()); 

      }
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

      //Debug.Log("Trigger is working");
      */


    IEnumerator CountPressTimeCoroutine()
    {
        while (true)
        {
            if (Input.GetKey(KeyToScene))
                spaceHoldingTime += Time.deltaTime;
            else if (spaceHoldingTime > 0)
                OnSpaceReleased();
            yield return null;
        }
    }

    void OnSpaceReleased()
    {
        Debug.Log(spaceHoldingTime);
        spaceHoldingTime = 0;
    }
    IEnumerator LoadScene()
    {
        PlayerStorage.initialValue = position;
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync(m_SceneName);
        anim.SetTrigger("FadeOut");

        while (!AsyncLoad.isDone)
        {            
            yield return null;
        }
    }
}
