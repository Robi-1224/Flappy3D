using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    private ObstacleSpawner obstacleSpawner;
    // Start is called before the first frame update
    void Start()
    {
        obstacleSpawner = FindAnyObjectByType<ObstacleSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
            
    }

    private void Moving()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        obstacleSpawner.obstaclesSpawned.Remove(gameObject);
        obstacleSpawner.coinsSpawned.Remove(gameObject);
    }

}
