using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DeleteJson : MonoBehaviour
{
    string path = "/Users/harshbharadwaj/Documents/GitHub/MyPuzzlePlatformer/Assets" + "/PlayerData.json";
    private void Start()
    {
      
        Button deleteButton = GetComponent<Button>();

        if (deleteButton != null)
        {
           
            deleteButton.onClick.AddListener(DeleteJsonFile);
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject.");
        }
    }

    private void DeleteJsonFile()
    {
        
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("JSON file deleted: " + path);

        
            CloseGameplayWindow();
        }
        else
        {
            Debug.LogWarning("JSON file not found: " + path);
        }
    }

    private void CloseGameplayWindow()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
