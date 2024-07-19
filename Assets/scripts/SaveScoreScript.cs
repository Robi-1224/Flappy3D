
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(Score))]
public class SaveScoreScript : MonoBehaviour
{
    private Score score;
    private string savePath;
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Score>();
        savePath = Application.persistentDataPath + "/highscore.save";
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
            

        };

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
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

            score.highScore = save.savedHighScore;
       

            Debug.Log("Highscore Loaded");
        }
         
        

           
            
           
        
    }
}
