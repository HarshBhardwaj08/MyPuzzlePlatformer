using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExtractJson : SingleteornClass<ExtractJson>
{
    public static ExtractJson instance;
    public PlayerData data;
    protected override void Awake()
    {
        base.Awake();
        LoadPlayerData();
    }


    void LoadPlayerData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "PlayerData.json");

        
        if (File.Exists(filePath))
        {
            string jsonData = System.IO.File.ReadAllText(filePath);
            data = JsonUtility.FromJson<PlayerData>(jsonData);
            //Debug.Log("Player data loaded from JSON at: " + filePath);
           // Debug.Log(data.checkpoint.position);
        }
        else
        {
            Debug.LogWarning("Player data file not found at: " + filePath);
        }
    }


}
