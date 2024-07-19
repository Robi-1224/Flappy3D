using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float timeToSpawn;
    public List<GameObject> obstaclesSpawned;
    private Vector3 randomSpawnYPos;

    
    private ButtonManager buttonManager;
    private bool hasStarted = false;
    private bool canDestroy = true;
    // Start is called before the first frame update
    void Start()
    {
        buttonManager = FindAnyObjectByType<ButtonManager>();
        hasStarted = false;
        StartCoroutine(SpawningObstacles());
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
           
        }

    }

    private IEnumerator SpawningObstacles()
    {
        while (true)
        {
            if (!buttonManager.isPaused)
            {
                
                randomSpawnYPos = new Vector3(spawnPoint.transform.position.x, Random.Range(-5, 5), spawnPoint.transform.position.z);
                WaitForSeconds wait = new WaitForSeconds(timeToSpawn);
                var obstacles = Instantiate(obstacle, spawnPoint.transform.position, Quaternion.identity);
                obstaclesSpawned.Add(obstacles);
                obstacles.transform.position = randomSpawnYPos;
                if (canDestroy)
                {
                    Destroy(obstacles, 5f);
                }
                obstacles.transform.SetParent(spawnPoint.transform);
                yield return wait;
            }

            
          
        }
    }

    
}
