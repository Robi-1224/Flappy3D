
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using SgLib;

public class SkinManager : MonoBehaviour
{
    public List<GameObject> skins;
    public List<string> unlockedSkins ;

    public int skinsIndex =0;

    public MeshRenderer currentSkin;
    private Score score;
    private UnlockedCheck unlockedCheck;
    public TextMeshProUGUI amountText;


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu")){
            amountText.text = "Cost: " + skins[skinsIndex].gameObject.GetComponent<UnlockedCheck>().coinCost;
        }

    }
    private void Start()
    {
        score = FindAnyObjectByType<Score>();
        unlockedCheck = FindAnyObjectByType<UnlockedCheck>();
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

        if (skinsIndex == 2)
        {
            skinsIndex = 0;
        }
        else
        {
            skinsIndex++;
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

        
        if (skinsIndex == 0)
        {
            skinsIndex = 27;
        }
        else
        {
            skinsIndex--;
          
        }
      
      
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
                unlockedSkins.Add(skins[skinsIndex].gameObject.tag);
                skins[skinsIndex].gameObject.GetComponent<UnlockedCheck>().unlcocked = true;
                Debug.Log("unlocked");
            }
        }
        else
        {
            Debug.Log("not unlocked");
          
        }
    }
}

