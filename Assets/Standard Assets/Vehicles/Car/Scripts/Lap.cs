using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SaveScript.WWTextReset = true;
            StartCoroutine(WrongWayReset());
            if (SaveScript.RaceOver == false)
            {
                if (SaveScript.HalfWayActivated == true)
                {
                    SaveScript.HalfWayActivated = false;
                    SaveScript.LastLapMinutes = SaveScript.LapTimeMinutes;
                    SaveScript.LastLapSeconds = SaveScript.LapTimeSeconds;
                    SaveScript.LapNumber++;
                    SaveScript.LapChange = true;
                    if (SaveScript.LapNumber == SaveScript.MaxLaps)
                    {
                        SaveScript.BestLapTimeMinutes = SaveScript.LastLapMinutes;
                        SaveScript.BestLapTimeSeconds = SaveScript.LastLapSeconds;
                    }
                    SaveScript.CheckPointPass1 = false;
                    SaveScript.CheckPointPass2 = false;
                    SaveScript.LastCheckPoint1 = SaveScript.ThisCheckPoint1;
                    SaveScript.LastCheckPoint2 = SaveScript.ThisCheckPoint2;
                }
            }
        }
        if(other.gameObject.CompareTag("ProgressAI1"))
        {
            SaveScript.AICar1LapNumer++;
        }
        if (other.gameObject.CompareTag("ProgressAI2"))
        {
            SaveScript.AICar2LapNumer++;
        }
        if (other.gameObject.CompareTag("ProgressAI3"))
        {
            SaveScript.AICar3LapNumer++;
        }
        if (other.gameObject.CompareTag("ProgressAI4"))
        {
            SaveScript.AICar4LapNumer++;
        }
        if (other.gameObject.CompareTag("ProgressAI5"))
        {
            SaveScript.AICar5LapNumer++;
        }
        if (other.gameObject.CompareTag("ProgressAI6"))
        {
            SaveScript.AICar6LapNumer++;
        }
        if (other.gameObject.CompareTag("ProgressAI7"))
        {
            SaveScript.AICar7LapNumer++;
        }
    }
    IEnumerator WrongWayReset()
    {
        yield return new WaitForSeconds(1f);
        SaveScript.WWTextReset = false;
    }
}
