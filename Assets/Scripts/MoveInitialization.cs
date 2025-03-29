using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveInitialization : MonoBehaviour
{
    public Button moveOnButton;
    // Start is called before the first frame update
    void Start()
    {
        SceneLoader sceneLoader = SceneLoader.Instance;

        if (sceneLoader != null)
        {
            moveOnButton.onClick.AddListener(sceneLoader.LoadNextScene);
        }
        else
        {
            Debug.Log("SCENE INSTANCE NOT FOUND AT ALL!!!");
        }
    }
}
