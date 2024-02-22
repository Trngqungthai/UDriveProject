using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UIElements;

public class OptionsMenu : MonoBehaviour
{
    public Text Mode;
    public Text LapCount;
    public Text OpponentCount;
    private bool TimeTrial = true;
    private int CurrentLapCount = 1;
    private int CurrentOpponentCount = 1;
    public int TimeTrialSceneNumber;
    public int RaceTrackSceneNumber;
    public GameObject LoadScreen;
    public GameObject OpponentsOn;
    public GameObject LapsOn;

    private void Start()
    {
        TimeTrial = true;
        Mode.text = "TIME TRIAL";
        CurrentLapCount = 1;
        LapCount.text = CurrentLapCount + " LAP";
        CurrentOpponentCount = 1;
        OpponentCount.text = CurrentOpponentCount + " OPPONENTS";
        LoadScreen.SetActive(false);
        if (TimeTrial == true)
        {
            OpponentsOn.SetActive(false);
        }
    }
    public void ModeNext()
    {
        if (TimeTrial == true)
        {
            Mode.text = "RACE";
            TimeTrial = false;
            OpponentsOn.SetActive(true);
            LapsOn.SetActive(true);
        }
    }
    public void ModeBack()
    {
        if (TimeTrial == false)
        {
            Mode.text = "TIME TRIAL";
            TimeTrial = true;
            OpponentsOn.SetActive(false);
            LapsOn.SetActive(false);
        }
    }
    public void LapCountNext()
    {
        if (CurrentLapCount < 5)
        {
            CurrentLapCount++;
            LapCount.text = CurrentLapCount + " LAPS";
            UniversalSave.LapCounts = CurrentLapCount;
        }
    }
    public void LapCountBack()
    {
        if (CurrentLapCount > 2)
        {
            CurrentLapCount--;
            LapCount.text = CurrentLapCount + " LAPS";
            UniversalSave.LapCounts = CurrentLapCount;
        }
        else if (CurrentLapCount == 2)
        {
            CurrentLapCount--;
            LapCount.text = CurrentLapCount + " LAP";
            UniversalSave.LapCounts = CurrentLapCount;
        }
    }
    public void OpponentsNext()
    {
        if (CurrentOpponentCount < 7)
        {
            CurrentOpponentCount++;
            OpponentCount.text = CurrentOpponentCount + " OPPONENTS";
            UniversalSave.OpponentCounts = CurrentOpponentCount;
        }
    }
    public void OpponentsBack()
    {
        if (CurrentOpponentCount > 2)
        {
            CurrentOpponentCount--;
            OpponentCount.text = CurrentOpponentCount + " OPPONENTS";
            UniversalSave.OpponentCounts = CurrentOpponentCount;
        }
        else if (CurrentOpponentCount == 2)
        {
            CurrentOpponentCount--;
            OpponentCount.text = CurrentOpponentCount + " OPPONENT";
            UniversalSave.OpponentCounts = CurrentOpponentCount;
        }
    }
    public void BeginRace()
    {
        if(TimeTrial == true) 
        {
            StartCoroutine(WaitToLoad());
            
        }
        if (TimeTrial == false)
        {
            StartCoroutine(WaitToLoad2());
            
        }
    }
    public void ResetValues()
    {
        SaveScript.LapNumber = 0;
        SaveScript.LapChange = false;
        SaveScript.RaceTimeMinutes = 0f;
        SaveScript.RaceTimeSeconds = 0f;
        SaveScript.LapTimeMinutes = 0f;
        SaveScript.LapTimeSeconds = 0f;
        SaveScript.GameTime = 0f;
        SaveScript.LapNumber = 0;
        SaveScript.LastCheckPoint1 = 0;
        SaveScript.ThisCheckPoint1 = 0;
        SaveScript.LastCheckPoint2 = 0;
        SaveScript.ThisCheckPoint2 = 0;
        SaveScript.CheckPointPass1 = false;
        SaveScript.CheckPointPass2 = false;
        SaveScript.NewRecord = false;
        SaveScript.OnTheRoad = true;
        SaveScript.OnTheTerrain = false;
        SaveScript.Rumble1 = false;
        SaveScript.Rumble2 = false;
        SaveScript.WrongWay = false;
        SaveScript.HalfWayActivated = true;
        SaveScript.WWTextReset = false;
        SaveScript.RaceStart = false;
        SaveScript.RaceOver = false;
        SaveScript.Gold = false;
        SaveScript.Silver = false;
        SaveScript.Bronze = false;
        SaveScript.Fail = false;
        SaveScript.BrakeSlide = false;
        
        SaveScript.PenaltySeconds = 0;
        SaveScript.AICar1LapNumer = 0;
        SaveScript.AICar2LapNumer = 0;
        SaveScript.AICar3LapNumer = 0;
        SaveScript.AICar4LapNumer = 0;
        SaveScript.AICar5LapNumer = 0;
        SaveScript.AICar6LapNumer = 0;
        SaveScript.AICar7LapNumer = 0;
        SaveScript.FinishPositionID = 0;
        SaveScript.PlayerPosition = 0;
        Time.timeScale = 1f;
    }
    IEnumerator WaitToLoad()
    {
        ResetValues();
        yield return new WaitForSeconds(0.3f);
        LoadScreen.SetActive(true);
        UniversalSave.LapCounts = CurrentLapCount;
        UniversalSave.OpponentCounts = 0;
        SceneManager.LoadScene(TimeTrialSceneNumber);
    }
    IEnumerator WaitToLoad2()
    {
        ResetValues();
        yield return new WaitForSeconds(0.3f);
        LoadScreen.SetActive(true);
        UniversalSave.LapCounts = CurrentLapCount;
        UniversalSave.OpponentCounts = CurrentOpponentCount;
        SceneManager.LoadScene(RaceTrackSceneNumber);
    }

}
