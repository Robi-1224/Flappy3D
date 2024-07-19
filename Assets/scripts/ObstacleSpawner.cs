using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float timeToSpawn;
    private float timeToDestroy = 5f;
    public List<GameObject> obstaclesSpawned;
    private Vector3 randomSpawnYPos;


    private ButtonManager buttonManager;
    private bool hasStarted = false;
    private bool hasFinished = false;
    private bool canDestroy = true;
    // Start is called before the first frame update
    void Start()
    {
        buttonManager = FindAnyObjectByType<ButtonManager>();
        hasStarted = false;
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (buttonManager.isPaused)
        {

            canDestroy = false;

            foreach (GameObject move in obstaclesSpawned)
            {
                move.GetComponent<Movement>().enabled = false;

            }
            StopAllCoroutines();
            hasStarted = false;
            hasFinished = false;
        }
        else
        {
            foreach (GameObject move in obstaclesSpawned)
            {
                move.GetComponent<Movement>().enabled = true;

            }
            hasFinished = true;
        }

        if(hasFinished)
        {
            if (!hasStarted)
            {
                hasStarted = true;
                StartCoroutine(SpawningObstacles());
            }
        }
    } 




        private IEnumerator SpawningObstacles()
        {
            while (true) {
            timeToDestroy = 5;
            timeToDestroy -= Time.deltaTime;
          
            randomSpawnYPos = new Vector3(spawnPoint.transform.position.x, Random.Range(-5, 5), spawnPoint.transform.position.z);
                WaitForSeconds wait = new WaitForSeconds(timeToSpawn);
                var obstacles = Instantiate(obstacle, spawnPoint.transform.position, Quaternion.identity);
                obstaclesSpawned.Add(obstacles);
                obstacles.transform.position = randomSpawnYPos;

                if (!buttonManager.isPaused)
                {
                Time.timeScale = 1;
                if (timeToDestroy <= 0)
                {
                    Destroy(obstacles);
                }
               
            }
            else
            {
                 Time.timeScale = 0;
            }
                obstacles.transform.SetParent(spawnPoint.transform);
                yield return wait;

            }


          

        }


    
}
