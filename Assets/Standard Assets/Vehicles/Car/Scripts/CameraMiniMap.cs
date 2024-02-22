using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMiniMap : MonoBehaviour
{
    public Transform target;
    public float height = 10f;
    public float smoothSpeed = 0.5f;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0f, height, 0f);
    }

    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.rotation = Quaternion.Euler(90f, -90f, 0f);
    }
}