using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Sprite CheckpointspriteOn,CheckpointSpriteOff;
  //  public GameObject CystalManager;
    public GameObject coinManger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().sprite = CheckpointspriteOn;
            SaveData();
        }
    }

    private void SaveData()
    {
        PlayerData playerData = new PlayerData();
        playerData.checkpoint = this.transform;

        playerData.gemCollected = CoinManager.Instance.getGemsScore();
        playerData.cystalCollected = CystalManager.Instance.getCystalScore();
        string filePath = Path.Combine(Application.persistentDataPath, "PlayerData.json");
        var jsonString = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, jsonString);
        Debug.Log("Player data saved to JSON at: " + filePath);
    }
}
