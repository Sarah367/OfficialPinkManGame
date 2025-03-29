using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void BackToStart()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
        ItemCollector.Reset();
    }
}
