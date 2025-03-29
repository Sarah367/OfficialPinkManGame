using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaveLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void SaveAndExit()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentScene);

        int oranges = PlayerPrefs.GetInt("OrangesCount", 0);
        int kiwis = PlayerPrefs.GetInt("KiwisCount", 0);
        int strawberries = PlayerPrefs.GetInt("StrawberriesCount", 0);
        int princessItems = PlayerPrefs.GetInt("PrincessItemsCount", 0);
        PlayerPrefs.SetInt("SavedOranges", oranges);
        PlayerPrefs.SetInt("SavedKiwis", kiwis);
        PlayerPrefs.SetInt("SavedStrawberries", strawberries);
        PlayerPrefs.SetInt("SavedPrincessItems", princessItems);
        PlayerPrefs.SetInt("GameSaved", 1);
        PlayerPrefs.Save();

        Debug.Log("Game Stats Saved!");
        Application.Quit();
    }
}
