using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] int force;
    [SerializeField] bool canFlap;
    private float flappingCooldown = 0;
    [SerializeField] float coolDown;

    [SerializeField] GameObject gameOverScreen;

    [SerializeField] Transform lookPoint;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFlapping();

    }


    private void PlayerFlapping()
    {

        rb.transform.LookAt(lookPoint);

        if (!canFlap)
        {
            flappingCooldown += Time.deltaTime;

            if (flappingCooldown >= coolDown)
            {
                canFlap = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {


            if (canFlap)
            {

                rb.velocity = Vector3.zero;
                rb.AddForce(0, force, 0, ForceMode.Impulse);
                flappingCooldown = 0;
                canFlap = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        float screenBorderForce = 3000;

        // top and bottom of the screen
        if (collision.gameObject.CompareTag("ScreenBorderTop"))
        {
           
            rb.AddForce(0,-screenBorderForce,0, ForceMode.Impulse);

        }
        
        else if (collision.gameObject.CompareTag("ScreenBorderBottom"))
        {
           
            rb.AddForce(-screenBorderForce, 10, 0, ForceMode.Impulse);
            gameOver = true;
            Destroy(gameObject, .2f);
        }

        // different kind of obstacles
        if (collision.gameObject.CompareTag("Obstacle"))
        {
           
            Destroy(gameObject, .2f);
            gameOver = true;
        }
        else if (collision.gameObject.CompareTag("ElectricObstacle"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject,.2f);
            gameOver=true;
            
        }
    }


    
}


