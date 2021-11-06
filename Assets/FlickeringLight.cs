using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private float x;
    private float y;
    private Light playerLight;

    void Start()
    {
        playerLight = GetComponent<Light>();
    }

    void Update()
    {  
        x = Mathf.Round(Mathf.Sin(Time.timeSinceLevelLoad * 50f) + 1);      
        y = Mathf.Cos(Time.timeSinceLevelLoad * 12f) / 400f;

        playerLight.range -= (x - 1) / 800f;
        playerLight.range += y;

        playerLight.range = Mathf.Clamp(playerLight.range, 3.45f, 3.55f);
    }
}
