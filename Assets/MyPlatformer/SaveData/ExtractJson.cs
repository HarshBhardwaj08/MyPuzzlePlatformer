using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractJson : MonoBehaviour
{
    public static ExtractJson instance;
    public PlayerData data;
    void Awake()
    {
        instance = this;
        string jsonData = System.IO.File.ReadAllText("/Users/harshbharadwaj/Documents/GitHub/MyPuzzlePlatformer/Assets" + "/PlayerData.json");

        // Convert JSON back to C# object
        data = JsonUtility.FromJson<PlayerData>(jsonData);
        Debug.Log(data.checkpoint.position);
    }

   
}
