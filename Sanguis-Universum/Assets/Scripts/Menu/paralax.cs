using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    
    void Start()
    {
        transform.position = new Vector3(3.8f, 4.09f, -13);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Input.mousePosition.x * 0.001f, Input.mousePosition.y * 0.001f, -13);
    }
}
