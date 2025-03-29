using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitApp()
    {
        Debug.Log("EXIT GAME");
        ItemCollector.Reset();
        PlayerPrefs.DeleteKey("GameSaved");
        PlayerPrefs.DeleteKey("SavedScene");
        PlayerPrefs.DeleteKey("SavedOranges");
        PlayerPrefs.DeleteKey("SavedKiwis");
        PlayerPrefs.DeleteKey("SavedStrawberries");
        PlayerPrefs.DeleteKey("SavedPrincessItems");
        PlayerPrefs.DeleteKey("SavedJumps");
        PlayerPrefs.Save();
        Application.Quit();
        #if UNITY_EDITOR
            Debug.Log("Game is exiting");
        #endif
    }


}
