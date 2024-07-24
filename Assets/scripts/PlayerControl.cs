using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool gameStarted = false;
    public bool gameOver = false;

    private Score score;
    private ButtonManager buttonManager;
    private SkinManager skinManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = FindAnyObjectByType<Score>();
        buttonManager = FindAnyObjectByType<ButtonManager>();
        skinManager = FindAnyObjectByType<SkinManager>();

        if (gameOverHighscoreText == null)
        {
            gameOverHighscoreText = GameObject.Find("Current Highscore").GetComponent<TextMeshProUGUI>();
        }

        if (skinManager.skins[skinManager.skinsIndex].GetComponent<MeshFilter>() != null)
        {

            skinManager.currentSkin.GetComponent<MeshFilter>().mesh = skinManager.skins[skinManager.skinsIndex].GetComponent<MeshFilter>().mesh;
        }
        else
        {
            skinManager.currentSkin.GetComponent<MeshFilter>().mesh = skinManager.skins[skinManager.skinsIndex].GetComponentInChildren<MeshFilter>().mesh;
        }

        if (skinManager.skins[skinManager.skinsIndex].GetComponent<MeshRenderer>() != null)
        {
            skinManager.currentSkin.GetComponent<MeshRenderer>().material = skinManager.skins[skinManager.skinsIndex].GetComponent<MeshRenderer>().material;
        }
        else
        {
            skinManager.currentSkin.GetComponent<MeshRenderer>().material = skinManager.skins[skinManager.skinsIndex].GetComponentInChildren<MeshRenderer>().material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFlapping();

        if (gameOver)
        {

            gameOverScreen.SetActive(true);
            gameOverHighscoreText.text = "Current Champion " +score.championText +"'s" + " Highscore: " + score.highScore;
            score.endScore = score.score;
            score.HighScore();

        }

        if (!gameStarted && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            buttonManager.isPaused = true;
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            rb.useGravity = true;

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

  

