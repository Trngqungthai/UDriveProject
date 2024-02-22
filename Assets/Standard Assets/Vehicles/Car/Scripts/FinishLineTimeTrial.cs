using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTimeTrial : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SaveScript.RaceOver = true;
            Time.timeScale = 0.5f;
        }
    }
}
