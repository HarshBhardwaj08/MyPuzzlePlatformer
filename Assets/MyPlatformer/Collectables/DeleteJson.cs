using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DeleteJson : MonoBehaviour
{
 
    private string fileName = "PlayerData.json";

    private string filePath;

    private void Start()
    {
       
        filePath = Path.Combine(Application.persistentDataPath, fileName);

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
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("JSON file deleted: " + filePath);

            CloseGameplayWindow();
        }
        else
        {
            Debug.LogWarning("JSON file not found: " + filePath);
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
