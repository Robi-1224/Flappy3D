using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedCheck : MonoBehaviour
{
    public int coinCost;
    private SkinManager skinManager;
    private Score score;
    public bool unlcocked = false;
   
    // Start is called before the first frame update
    void Start()
    {
        skinManager = FindAnyObjectByType<SkinManager>();
        score = FindAnyObjectByType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockingSkin()
    {
        skinManager.UnlockCheck(coinCost);
        score.coinsCollected -= coinCost;
    }
}
