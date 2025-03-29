using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOVSlider : MonoBehaviour
{
    public Slider fovSlider;
    private Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
        fovSlider.onValueChanged.AddListener(AdjustFOV);
        fovSlider.value = mainCamera.orthographicSize;
        fovSlider.minValue = 3;
        fovSlider.maxValue = 8;
    }

    // Update is called once per frame
    private void AdjustFOV(float value)
    {
        mainCamera.orthographicSize = value;
    }
}
