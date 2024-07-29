using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
    [SerializeField] GameObject[] backgrounds;
    public GameObject[] obstacleList;
    [SerializeField] Transform spawnPoint;

    private int beginScoreToUpdate;
    public int backgroundIndex;
    public int obstacleIndex;
    [SerializeField] private int scoreToUpdate;

    public bool canUpdate = false;
    private bool updated = false;

    private Score score;
    private BackgroundLoop loop;
    private ObstacleSpawner obstacleSpawner;

    
  
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Score>();
        loop = GetComponent<BackgroundLoop>();
        obstacleSpawner = GetComponent<ObstacleSpawner>();

        backgroundIndex = 0;
        obstacleIndex = 0;

        canUpdate = false;
        updated = false;

        beginScoreToUpdate = scoreToUpdate;
       
    }

    // Update is called once per frame
    void Update()
    {
        obstacleList[obstacleIndex].transform.position = spawnPoint.position;
        BackgroundUpdate();
        
        
    }

    private void BackgroundUpdate()
    {
       
        if (score.score >= scoreToUpdate)
        {
            scoreToUpdate += beginScoreToUpdate;
            updated = true;

            if (updated)
            {
                canUpdate = false;
           
                if (!canUpdate)
                {
                    canUpdate = true;
                    updated = false;
                    backgroundIndex++;
                    obstacleIndex++;


                   var disableIndex = backgroundIndex - 1;
                   backgrounds[disableIndex].gameObject.SetActive(false);

                }
            }

            if (backgroundIndex != 3)
            {
                backgrounds[backgroundIndex].gameObject.SetActive(true);
                loop.background = backgrounds[backgroundIndex].GetComponent<Transform>();
             
            }
            else
            {
                backgroundIndex = 0;
                obstacleIndex = 0;
                backgrounds[backgroundIndex].gameObject.SetActive(true);
                loop.background = backgrounds[backgroundIndex].GetComponent<Transform>();

            }
        }


      

    }
}
