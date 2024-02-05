using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
 
public class JsonReadWriteSystem : MonoBehaviour
{
    public DriftManager driftManager;
    private String nameInput;
    private float cashInput;
 
    public void SaveToJson()
    {
        cashInput = driftManager.totalScore;

        PlayerData data = new PlayerData();
        data.Name = nameInput;
        data.Cash = cashInput.ToString();
 
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/PlayerDataFile.json", json);
    }
 
    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/PlayerDataFile.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
 
       
        nameInput = data.Name;
        cashInput =  Convert.ToInt32(data.Cash);
    }
}