using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    public int spawnedCoinIndex =-1;
 
    [SerializeField] float timeToSpawn;
    public List<GameObject> obstaclesSpawned;
    public List<GameObject> coinsSpawned;
    public GameObject coin;
    private Vector3 randomSpawnYPos;


    private ButtonManager buttonManager;
    private BackgroundChange backgroundChange;
    private BackgroundLoop backgroundLoop;
    private bool hasStarted = false;
    private bool hasFinished = false;
    private bool canDestroy = true;
    // Start is called before the first frame update
    void Start()
    {
        buttonManager = FindAnyObjectByType<ButtonManager>();
        backgroundChange = GetComponent<BackgroundChange>();
        backgroundLoop = GetComponent<BackgroundLoop>();
        hasStarted = false;
      
    }

    // Update is called once per frame
    void Update()
    {
       

        if (buttonManager.isPaused)
        {
            if (!backgroundLoop.timerOn)
            {
                Time.timeScale = 0f;
            }
            canDestroy = false;

            foreach (GameObject move in obstaclesSpawned)
            {
                move.GetComponent<Movement>().enabled = false;

            }

            foreach (GameObject move in coinsSpawned)
            {
                move.GetComponent <Movement>().enabled = false;
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

            foreach (GameObject move in coinsSpawned)
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
                StartCoroutine(SpawningCoins());
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

    private IEnumerator SpawningCoins()
    {
        while (true)
        {
            WaitForSeconds wait = new WaitForSeconds(2);
            var coins = Instantiate(coin, backgroundChange.obstacleList[backgroundChange.obstacleIndex].GetComponentInChildren<Rigidbody>().gameObject.transform.position, Quaternion.identity);
            coinsSpawned.Add(coins);
            coins.transform.SetParent(backgroundChange.obstacleList[backgroundChange.obstacleIndex].GetComponentInChildren<Rigidbody>(true).gameObject.transform);
            if (canDestroy)
            {
                Destroy(coins, 4f);
            }
            yield return wait;
        }
    }
    
}
