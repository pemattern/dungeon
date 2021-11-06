using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    private float scale;
    void Start()
    {
        
    }
    void Update()
    {
        scale = (Mathf.Sin(Time.timeSinceLevelLoad) / 2) + 1.0f;
        transform.RotateAround(transform.position, Vector3.up, 0.2f);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
