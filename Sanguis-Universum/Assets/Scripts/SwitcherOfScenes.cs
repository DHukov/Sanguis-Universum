using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SwitcherOfScenes : MonoBehaviour
{
    [SerializeField] string m_SceneName;
    [SerializeField] float time;


    public Vector3 position;
    public VectorValue PlayerStorage;

    private bool HasPlayer;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Tab) && HasPlayer == true)
        {
            StartCoroutine(LoadScene());

            //StartCoroutine(Action());

            //anim.Play("ToFade");
        }
        if (Input.GetKeyUp(KeyCode.Tab) || HasPlayer == false)
        {
            // StopCoroutine(Action());
            StartCoroutine(LoadScene());

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

    IEnumerator Action()
    {
        yield return new WaitForSeconds(time);

        Debug.Log("Time" + time);
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
