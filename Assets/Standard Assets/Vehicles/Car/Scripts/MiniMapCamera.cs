using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 Offset;

    void Update()
    {
        transform.position = target.transform.position + Offset;  
    }
}
