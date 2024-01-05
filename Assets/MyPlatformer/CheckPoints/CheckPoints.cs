using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Sprite Checkpointsprite;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().sprite = Checkpointsprite;
            SaveData();
        }
    }

    private void SaveData()
    {
        PlayerData playerData = new PlayerData();
        playerData.checkpoint = this.transform;
        playerData.gemCollected = UIManager.instance.GetScore();

        var jsonString = JsonUtility.ToJson(playerData);
        File.WriteAllText("/Users/harshbharadwaj/Documents/GitHub/MyPuzzlePlatformer/Assets" + "/PlayerData.json" , jsonString);
    }
}
