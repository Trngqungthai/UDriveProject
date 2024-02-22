using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    private AudioSource player;
    private bool IsPlaying = false;
    public int CurrentWP = 0;
    public int ThisWPNumber;
    public int LastMPNumber;
    void Start()
    {
        player = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Barrier"))
        {
            if(IsPlaying == false) 
            {
                IsPlaying = true;
                player.Play();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            if (IsPlaying == true)
            {
                IsPlaying = false;
            }
        }
    }
    private void Update()
    {
        if(SaveScript.LapChange == true)
        {
            CurrentWP = 0;
        }
        if(CurrentWP > LastMPNumber) 
        {
            StartCoroutine(CheckDirection());
        }
        if(LastMPNumber > ThisWPNumber) 
        {
            SaveScript.WrongWay = false;
        }
        if ((LastMPNumber < ThisWPNumber))
        {
            if (LastMPNumber == 1)
            {
                SaveScript.WrongWay = false;
            }
            else
            {
                SaveScript.WrongWay = true;
            }
        }
        /*Debug.Log("ThisWPNumber: " + ThisWPNumber);
        Debug.Log("LastMPNumber: " + LastMPNumber);*/
    }

    IEnumerator CheckDirection()
    {
        yield return new WaitForSeconds(0.5f);
        ThisWPNumber = LastMPNumber;
    }
}
