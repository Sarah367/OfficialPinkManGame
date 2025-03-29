using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject TopRightOptions;
    private static SceneLoader instance;
    public static SceneLoader Instance
    {
        get
        {
            return instance;
        }
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("SceneLoader initialized");
        }
        else
        {
            Destroy(gameObject);

            Debug.Log("Duplicate SceneLoader destroyed");
        }
    }
    // Start is called before the first frame update

    void Start()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (TopRightOptions != null)
        {
            if (currentSceneIndex == 0 || currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1 || currentSceneIndex == 5)
            {
                TopRightOptions.SetActive(false);
            }
            else
            {
                TopRightOptions.SetActive(true);
            }
        }

    }
   
    public void CheckWinConditions(int oranges, int kiwis, int strawberries, int princessItems)
    {
        Debug.Log("CHECK WIN CONDITION");
        Debug.Log("Oranges count IS: " + oranges);
        Debug.Log("Kiwis count IS: " + kiwis);
        Debug.Log("Princess Items count IS: " + princessItems);
        if (oranges >= 30 && kiwis >= 30 && strawberries >= 30 && princessItems == 4)
        {
            SceneManager.LoadScene(12);
        }
        else
        {
            SceneManager.LoadScene(13);
        }
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

}
