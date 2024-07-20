using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject spawnPoint;
 
    [SerializeField] float timeToSpawn;
    public List<GameObject> obstaclesSpawned;
    private Vector3 randomSpawnYPos;


    private ButtonManager buttonManager;
    private BackgroundChange backgroundChange;
    private bool hasStarted = false;
    private bool hasFinished = false;
    private bool canDestroy = true;
    // Start is called before the first frame update
    void Start()
    {
        buttonManager = FindAnyObjectByType<ButtonManager>();
        backgroundChange = GetComponent<BackgroundChange>();
        hasStarted = false;
      
    }

    // Update is called once per frame
    void Update()
    {
    

        if (buttonManager.isPaused)
        {
            Time.timeScale = 0f;
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
            Time.timeScale = 1f;
            foreach (GameObject move in obstaclesSpawned)
            {
                if (move)
                {
                    move.GetComponent<Movement>().enabled = true;
                }
            
            }
            hasFinished = true;
            canDestroy = true;
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


            randomSpawnYPos = new Vector3(spawnPoint.transform.position.x, Random.Range(-5, 5), spawnPoint.transform.position.z);
            WaitForSeconds wait = new WaitForSeconds(timeToSpawn);
            var obstacles = Instantiate(backgroundChange.obstacleList[backgroundChange.obstacleIndex], spawnPoint.transform.position, Quaternion.identity);
            obstaclesSpawned.Add(obstacles);
            obstacles.transform.position = randomSpawnYPos;

            obstacles.transform.SetParent(spawnPoint.transform);


            if (canDestroy)
            {
                Destroy(obstacles, 5f);
            }
            yield return wait;
        }


          

        }


    
}
