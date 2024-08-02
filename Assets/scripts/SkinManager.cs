
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;

public class SkinManager : MonoBehaviour
{
    public List<GameObject> skins;
    public List<GameObject> unlockedSkins;
    public int skinsIndex =0;

    public MeshRenderer currentSkin;
    private Score score;
    private UnlockedCheck unlockedCheck;
    public List<GameObject> lastSkinList = new List<GameObject>();
    public TextMeshProUGUI amountText;


    // Update is called once per frame
    void Update()
    {
      
        

    }
    private void Start()
    {
        score = FindAnyObjectByType<Score>();
        unlockedCheck = FindAnyObjectByType<UnlockedCheck>();
        amountText.text = "Cost: " + skins[skinsIndex].gameObject.GetComponent<UnlockedCheck>().coinCost;
        if (skins[skinsIndex].GetComponent<MeshFilter>() != null)
        {

            currentSkin.GetComponent<MeshFilter>().mesh = skins[skinsIndex].GetComponent<MeshFilter>().mesh;
        }
        else
        {
            currentSkin.GetComponent<MeshFilter>().mesh = skins[skinsIndex].GetComponentInChildren<MeshFilter>().mesh;
            if (skins[skinsIndex].GetComponent<MeshRenderer>() != null)
            {
                currentSkin.GetComponent<MeshRenderer>().material = skins[skinsIndex].GetComponent<MeshRenderer>().material;
            }
            else
            {
                currentSkin.GetComponent<MeshRenderer>().material = skins[skinsIndex].GetComponentInChildren<MeshRenderer>().material;
            }
        }
    }
    public void NextSkin()
    {
        skinsIndex++;

        amountText.text = "Cost: " + skins[skinsIndex].gameObject.GetComponent<UnlockedCheck>().coinCost;
        if (skinsIndex > 27)
        {
            skinsIndex = 0;
        }
    
        if (skins[skinsIndex].GetComponent<MeshFilter>() != null)
        {

            currentSkin.GetComponent<MeshFilter>().mesh = skins[skinsIndex].GetComponent<MeshFilter>().mesh;
        }
        else
        {
            currentSkin.GetComponent<MeshFilter>().mesh = skins[skinsIndex].GetComponentInChildren<MeshFilter>().mesh;
        }

        if (skins[skinsIndex].GetComponent<MeshRenderer>() != null)
        {
            currentSkin.GetComponent<MeshRenderer>().material = skins[skinsIndex].GetComponent<MeshRenderer>().material;
        }
        else
        {
            currentSkin.GetComponent<MeshRenderer>().material = skins[skinsIndex].GetComponentInChildren<MeshRenderer>().material;
        }
    }

    public void BackSkin()
    {

        amountText.text = "Cost: " + skins[skinsIndex].gameObject.GetComponent<UnlockedCheck>().coinCost;
        if (skinsIndex < 0) 
        {
            skinsIndex = 0;
        }

        skinsIndex--;
        if (skins[skinsIndex].GetComponent<MeshFilter>() != null) { 

            currentSkin.GetComponent<MeshFilter>().mesh = skins[skinsIndex].GetComponent<MeshFilter>().mesh;
        }
        else
        {
            currentSkin.GetComponent<MeshFilter>().mesh = skins[skinsIndex].GetComponentInChildren<MeshFilter>().mesh;
        }

        if (skins[skinsIndex].GetComponent<MeshRenderer>() != null)
        {
            currentSkin.GetComponent<MeshRenderer>().material = skins[skinsIndex].GetComponent<MeshRenderer>().material;
        }
        else
        {
            currentSkin.GetComponent<MeshRenderer>().material = skins[skinsIndex].GetComponentInChildren<MeshRenderer>().material;
        }
       
      
    }

    public void UnlockCheck(int amount)
    {
        if(score.coinsCollected >= amount)
        {
            if (skins[skinsIndex] != null)
            {
                unlockedSkins.Add(skins[skinsIndex]);
                Debug.Log("unlocked");
            }
        }
        else
        {
            unlockedCheck.unlcocked = false;
            Debug.Log("not unlocked");
          
        }
    }
}

