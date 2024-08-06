
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(Score))]
public class SaveScoreScript : MonoBehaviour
{
    private Score score;
    private SkinManager skinManager;
    private UnlockedCheck check;
    private string savePath;
    private string championsNamePath;
    private string skinIndexPath;
    private string coinNamePath;
    private string ownedSkinsPath;
    public bool InputName = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Score>();
        skinManager = FindAnyObjectByType<SkinManager>();
        check = FindAnyObjectByType<UnlockedCheck>();
        savePath = Application.persistentDataPath + "/highscore.save";
        championsNamePath = Application.persistentDataPath + "/champion.save";
        skinIndexPath = Application.persistentDataPath + "/currentSkin.save";
        coinNamePath = Application.persistentDataPath + "/coins.save";
        ownedSkinsPath = Application.persistentDataPath + "/ownedSkins.save";
        LoadData();
        
        

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SaveData()
    {
        var save = new Save()
        {
            savedHighScore = score.highScore,
            ChampionName = score.championText,
            currentSkinIndex = skinManager.skinsIndex,
            coinsSaved = score.coinsCollected,
            ownedSkin = skinManager.unlockedSkins,

        };

        var binaryFormatter = new BinaryFormatter();

        using (var fileStream = File.Create(savePath))
        {
           binaryFormatter.Serialize(fileStream, save);
        }

        using(var fileStream = File.Create(championsNamePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        using (var fileStream = File.Create(skinIndexPath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        using (var fileStream = File.Create(coinNamePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }
        using (var fileStream = File.Create(ownedSkinsPath))
        {
           binaryFormatter.Serialize(fileStream, save);
        }
        Debug.Log("HighScore Saved");
       
        
    }

    public void LoadData()
    {
        
        if (File.Exists(savePath))
        {
            Save save;

            var binaryFormatter = new BinaryFormatter();
            using(var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            using (var fileStream = File.Open(championsNamePath, FileMode.Open))
            {
                save =(Save)binaryFormatter.Deserialize(fileStream);
            }

            using (var fileStream = File.Open(skinIndexPath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            using (var fileStream = File.Open(coinNamePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }
           using (var fileStream = File.Open(ownedSkinsPath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            score.highScore = save.savedHighScore;
            score.championText = save.ChampionName;
            skinManager.skinsIndex = save.currentSkinIndex;
            score.coinsCollected = save.coinsSaved;
            skinManager.unlockedSkins = save.ownedSkin;

            Debug.Log("Highscore Loaded");
        }
       

           
            
           
        
    }


    public void ChampionNameInput(string s)
    {
        score.championText = s;

        if(s == "" || s== "Enter the champions name ") {

            InputName = false;
        }
        else
        {
            SaveData();
            InputName = true;
        }
       
    }
}
