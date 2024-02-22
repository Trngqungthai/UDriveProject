using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorTimeTrial : MonoBehaviour
{
    public GameObject FinishPoint;
    // Start is called before the first frame update
    void Start()
    {
        FinishPoint.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Progress"))
        {
            SaveScript.HalfWayActivated = true;
            if (SaveScript.LapNumber == SaveScript.MaxLaps)
            {
                FinishPoint.SetActive(true);
            }
        }
    }
}
