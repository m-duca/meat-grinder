using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class LightIntensityRuntime : MonoBehaviour
{
    public Light2D light2d;
    public float gameDuration;
    public float diminishingRate;
    float _initialTime;

    void Start()
    {
        _initialTime = Time.deltaTime;
    }

    void Update()
    {
        float _newOuterRadius = light2d.pointLightOuterRadius - (diminishingRate * Time.deltaTime);

        _newOuterRadius = Mathf.Max(_newOuterRadius, 0f);

        light2d.pointLightOuterRadius = _newOuterRadius;
    }

    public void IncreaseRadius(float aumento)
    {
        light2d.pointLightOuterRadius += aumento;
    }
}
