using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerControl playerControl;
    private Rigidbody rb;
    private Score score;
    private BackgroundLoop loop;
    private ObstacleSpawner obstacleSpawner;
    private FlashBang flash;
  
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<PlayerControl>();
        score = FindAnyObjectByType<Score>();
        rb = GetComponent<Rigidbody>();
        loop = FindAnyObjectByType<BackgroundLoop>();
        obstacleSpawner = FindAnyObjectByType<ObstacleSpawner>();
       flash = FindAnyObjectByType<FlashBang>();
   
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {

        float screenBorderForce = 3000;

        // top and bottom of the screen
        if (collision.gameObject.CompareTag("ScreenBorderTop"))
        {

            rb.AddForce(0, -screenBorderForce, 0, ForceMode.Impulse);

        }

        else if (collision.gameObject.CompareTag("ScreenBorderBottom"))
        {
           
                rb.AddForce(-screenBorderForce, 10, 0, ForceMode.Impulse);
                playerControl.gameOver = true;
                Destroy(gameObject, .2f);
        }

        // different kind of obstacles
        if (collision.gameObject.CompareTag("Obstacle"))
        {

            Destroy(gameObject, .1f);
            playerControl.gameOver = true;
        }

     else   if (collision.gameObject.CompareTag("ElectricObstacle"))
        {
            flash.canFlash = true;
            playerControl.gameOver = true;
            Destroy(gameObject, .1f);
          

        }

      else  if (collision.gameObject.CompareTag("FireObstacle"))
        {
            playerControl.gameOver = true;
            Destroy(gameObject, 0.1f);
           
        }
      else  if (collision.gameObject.CompareTag("IceObstacle"))
        {
            playerControl.gameOver= true;
            Destroy(gameObject, 0.1f);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        //score +1
        if (other.gameObject.CompareTag("ScoreBox"))
        {
            score.ScoreUpdate(1);
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            score.coinsCollected++;
            Destroy(obstacleSpawner.coinsSpawned[obstacleSpawner.spawnedCoinIndex]);
        }
    }



}


