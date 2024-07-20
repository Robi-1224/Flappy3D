using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI gameOverHighscoreText;
    [SerializeField] Transform lookPoint;
    public bool gameOver = false;

    private Score score;
    private SaveScoreScript script;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = FindAnyObjectByType<Score>();
        script = FindAnyObjectByType<SaveScoreScript>();

        if (gameOverHighscoreText == null)
        {
            gameOverHighscoreText = GameObject.Find("Current Highscore").GetComponent<TextMeshProUGUI>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        PlayerFlapping();


        if (gameOver)
        {

            gameOverScreen.SetActive(true);
            gameOverHighscoreText.text = "Champion" +score.championText +"'s" + " Highscore: " + score.highScore;
            score.endScore = score.score;
            score.HighScore();

        }
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
}

  

