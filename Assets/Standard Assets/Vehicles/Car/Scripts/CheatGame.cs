using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;


public class CheatGame : MonoBehaviour
{
    public GameObject CheatMenu;
    public GameObject FinishPoint;
    private bool isMenuVisible = false;    
    public void Update()
    {
        OnDisableMenu();
    }    
    public void Finish()
    {
        SaveScript.FinishPositionID++;
        SaveScript.RaceOver = true;

    }
    public void FinishRaceTrack()
    {
        FinishPoint.SetActive(true);
    }
    private void OnDisableMenu()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMenuVisible = !isMenuVisible;

            CheatMenu.SetActive(isMenuVisible);
        }
    }
}
