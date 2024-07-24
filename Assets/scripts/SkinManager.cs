
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections.Generic;

public class SkinManager : MonoBehaviour
{
    public GameObject[] skins;
    public int skinsIndex =0;

    public MeshRenderer currentSkin;
    
    public List<GameObject> lastSkinList = new List<GameObject>();
    

    // Update is called once per frame
    void Update()
    {
       
        

    }
    private void Start()
    {
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

        
        if(skinsIndex < 0) 
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
}

