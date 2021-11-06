using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    private Vector3 pos = new Vector3(0.0f, 0.0f, 1.52f);
    void Update()
    {
        pos.y = (Mathf.Sin(Time.timeSinceLevelLoad) / 100f) -0.862f;
        transform.localPosition = pos;
    }
}
