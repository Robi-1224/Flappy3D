using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLoop : MonoBehaviour
{

    Vector3 startPos;
    public Transform background;
    [SerializeField] TextMeshProUGUI readyToFlap;
    private ButtonManager buttonManager;
    public float timeLeft;
    public bool timerOn = false;

    public Text TimerTxt;
    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Start()
    {
       startPos = background.position;
       buttonManager = GetComponent<ButtonManager>();
       timerOn = true;

    }

    // Update is called once per frame
    void Update()
    {

        

        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                timeLeft = 0;
                timerOn = false;
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
        
        currentTime -= 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        readyToFlap.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
        
