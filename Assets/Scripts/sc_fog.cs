using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_fog : MonoBehaviour
{
    public Color coolor;
    public float startDistance, endDistance;
    void Start()
    {
        // Enable fog
        RenderSettings.fog = true;

        // Set fog color
        RenderSettings.fogColor = coolor;

        // Set fog mode
        RenderSettings.fogMode = FogMode.Linear;

        // Set linear fog start and end distances
        RenderSettings.fogStartDistance = startDistance;
        RenderSettings.fogEndDistance = endDistance;

        // Alternatively, you can adjust other fog properties like density for exponential fog mode
        // RenderSettings.fogDensity = 0.03f;
    }
}
