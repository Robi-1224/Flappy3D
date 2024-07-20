using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLoop : MonoBehaviour
{

    Vector3 startPos;
    public Transform background;
    // Start is called before the first frame update
    void Awake()
    {
        


    }

    private void Start()
    {
       startPos = background.position;



    }

    // Update is called once per frame
    void Update()
    {
        RepeatBackground();
    }

    private void RepeatBackground()
    {
       if(background.position.x < startPos.x -406.9)
        {
            background.position = startPos;
        }
    }
}
        
