using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float score = 0;
    [SerializeField] TextMeshProUGUI scoreTex;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameObject highScoreObject;
    public float endScore;
    public float highScore;
    private SaveScoreScript saveScoreScript;
    // Start is called before the first frame update
    void Start()
    {
        saveScoreScript = FindAnyObjectByType<SaveScoreScript>();
        saveScoreScript.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTex.text = "Score: " + score;
    }

    public void ScoreUpdate(int amount)
    {
        score += amount;
        
    }

    public void HighScore()
    {

        if(score > highScore)
        {
            highScore = endScore;
            highScoreObject.SetActive(true);
            saveScoreScript.SaveData();
            highScoreText.text = "You have a new HighScore: " + highScore;
        }

        
    }
}
