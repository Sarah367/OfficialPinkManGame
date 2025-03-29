using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instructionsPanel;
    
    public void ToggleInstructions()
    {
        instructionsPanel.SetActive(!instructionsPanel.activeSelf);
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
        //gameObject.SetActive(true);
        Debug.Log("Closing Instructions!");
    }
}
