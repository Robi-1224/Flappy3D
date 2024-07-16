using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float timeToSpawn;
    private Vector3 randomSpawnYPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningObstacles());
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private IEnumerator SpawningObstacles()
    {
        while (true)
        {
            randomSpawnYPos = new Vector3(spawnPoint.transform.position.x,Random.Range(-5, 5), spawnPoint.transform.position.z);
            
            WaitForSeconds wait = new WaitForSeconds(timeToSpawn);
            var obstacles = Instantiate(obstacle, spawnPoint.transform.position, Quaternion.identity);
            obstacles.transform.position = randomSpawnYPos;
            Destroy(obstacles, 5f);
            obstacles.transform.SetParent(spawnPoint.transform);
            yield return wait;
        }
    }
}
