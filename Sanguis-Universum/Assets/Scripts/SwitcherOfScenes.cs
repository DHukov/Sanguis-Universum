using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SwitcherOfScenes : MonoBehaviour
{
    [SerializeField] string m_SceneName;
    public float spaceHoldingTime = 0;
    [SerializeField] float time;

    public Vector3 position;
    public VectorValue PlayerStorage;

    private bool HasPlayer;

    public Animator anim;

    void Start()
    {
      /*  if(Input.GetKey(KeyCode.Tab))
        {
        StartCoroutine(CountPressTimeCoroutine());
        } */
        anim = GetComponent<Animator>();
    }

    public void Update()
    {

        if (Input.GetKey(KeyCode.Space) && HasPlayer == true)
        {
                StartCoroutine(CountPressTimeCoroutine());
          
        }
        else
        {

        }
       
        if (Input.GetKeyUp(KeyCode.Tab) || HasPlayer == false)
        {
            // StopCoroutine(Action());
            //StartCoroutine(LoadScene());

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.CompareTag("Player"))
        {
            //StartCoroutine(CountPressTimeCoroutine());

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
        Debug.Log("Couratine is starting");


        while (true)
        {
            /*
            if(time >= )
            {
    
                time = spaceHoldingTime =+ Time.deltaTime;
                Debug.Log("True");
                //StartCoroutine(LoadScene());
              
                //EnterToTheScene();
            }
            else if (spaceHoldingTime > 0)
            {
                OnSpaceReleased();
                //StopCoroutine(LoadScene());
                //StartCoroutine(LoadScene());
            }

            yield return null;
            //if (Input.GetKey(KeyCode.Space) && HasPlayer == true)

            //StartCoroutine(LoadScene());


            */
        }
    }
    void EnterToTheScene()
    {
        if(spaceHoldingTime >= Time.deltaTime)
        {
            StartCoroutine(LoadScene());
        }
        else
            OnSpaceReleased();
        
    }
    void OnSpaceReleased()
    {
        if(spaceHoldingTime >= 2)
        Debug.Log(spaceHoldingTime);
        spaceHoldingTime = 0;
    }
    /*
    IEnumerator Action()
    {
        yield return new WaitForSeconds(time);

        Debug.Log("Time" + time);
    }
    */
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
