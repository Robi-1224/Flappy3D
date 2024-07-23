using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLoop : MonoBehaviour
{

    Vector3 startPos;
    public Transform background;
    [SerializeField] TextMeshPro readyToFlap;
    [SerializeField] TextMeshPro controlText;

    private ButtonManager buttonManager;
    private PlayerControl playerControl;

    public float timeLeft;
    public bool timerOn = false;
    
   
    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Start()
    {
       startPos = background.position;
       buttonManager = GetComponent<ButtonManager>();
       playerControl = FindAnyObjectByType<PlayerControl>();
       timerOn = true;

    }

    // Update is called once per frame
    void Update()
    {


        if (playerControl.gameStarted)
        {


            if (timerOn)
            {
                if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    updateTimer(timeLeft);
                    buttonManager.isPaused = true;
                    Time.timeScale = 1;
                }
                else
                {
                    Debug.Log("Time is UP!");
                    timeLeft = 0;
                    timerOn = false;
                    readyToFlap.enabled = false;
                    controlText.enabled = false;
                    buttonManager.isPaused = false;
                }
            }
        }

        RepeatBackground();
    }

    private void RepeatBackground()
    {
       if(background.position.x < startPos.x -406.9)
        {
            background.position = startPos;
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        readyToFlap.enabled = true;
        controlText.enabled = true;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        readyToFlap.text = string.Format("Ready to flap?: "+ "{0:00}:{1:00}", minutes, seconds );
    }
}
        
