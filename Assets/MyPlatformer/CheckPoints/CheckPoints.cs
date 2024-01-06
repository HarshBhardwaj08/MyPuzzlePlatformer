using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Sprite Checkpointsprite;
    public GameObject Manager;
    private void Awake()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().sprite = Checkpointsprite;
            SaveData();
        }
    }

    private void SaveData()
    {
        PlayerData playerData = new PlayerData();
        playerData.checkpoint = this.transform;
        playerData.gemCollected = CoinManager.instance.GetComponent<CoinManager>().getCoinScore();
        // playerData.cystalCollected = CystalManager.instance.GetComponent<CystalManager>().getCystalScore();
        playerData.cystalCollected = Manager.GetComponent<CystalManager>().getCystalScore();
     
        string filePath = Path.Combine(Application.persistentDataPath, "PlayerData.json");

       
        var jsonString = JsonUtility.ToJson(playerData);

        
        File.WriteAllText(filePath, jsonString);

        Debug.Log("Player data saved to JSON at: " + filePath);
    }
}
