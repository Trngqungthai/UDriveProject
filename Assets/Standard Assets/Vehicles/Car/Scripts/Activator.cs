using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject FinishPoint;
    public GameObject FinishPointAI1;
    public GameObject FinishPointAI2;
    public GameObject FinishPointAI3;
    public GameObject FinishPointAI4;
    public GameObject FinishPointAI5;
    public GameObject FinishPointAI6;
    public GameObject FinishPointAI7;
    private void Start()
    {
        FinishPoint.SetActive(false);
        FinishPointAI1.SetActive(false);
        FinishPointAI2.SetActive(false);
        FinishPointAI3.SetActive(false);
        FinishPointAI4.SetActive(false);
        FinishPointAI5.SetActive(false);
        FinishPointAI6.SetActive(false);
        FinishPointAI7.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Progress"))
        {
            SaveScript.HalfWayActivated = true;
            if(SaveScript.LapNumber == SaveScript.MaxLaps)
            {
                FinishPoint.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("ProgressAI1"))
        {
            if (SaveScript.AICar1LapNumer == SaveScript.MaxLaps)
            {
                FinishPointAI1.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("ProgressAI2"))
        {
            if (SaveScript.AICar2LapNumer == SaveScript.MaxLaps)
            {
                FinishPointAI2.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("ProgressAI3"))
        {
            if (SaveScript.AICar3LapNumer == SaveScript.MaxLaps)
            {
                FinishPointAI3.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("ProgressAI4"))
        {
            if (SaveScript.AICar4LapNumer == SaveScript.MaxLaps)
            {
                FinishPointAI4.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("ProgressAI5"))
        {
            if (SaveScript.AICar5LapNumer == SaveScript.MaxLaps)
            {
                FinishPointAI5.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("ProgressAI6"))
        {
            if (SaveScript.AICar6LapNumer == SaveScript.MaxLaps)
            {
                FinishPointAI6.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("ProgressAI7"))
        {
            if (SaveScript.AICar7LapNumer == SaveScript.MaxLaps)
            {
                FinishPointAI7.SetActive(true);
            }
        }
    }
}
