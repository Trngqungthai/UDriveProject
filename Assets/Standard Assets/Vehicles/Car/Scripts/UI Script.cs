using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class UIScript : MonoBehaviour
{
    public Image SpeedRing;
    public Text SpeedText;
    public Text GearText;
    public Text TypeSpeedText;
    private float DisplaySpeed;    
    public Text LapNumberText;
    public Text TotalLapsText;
    public Text LapTimeMinutes;
    public Text LapTimeSeconds;
    public Text RaceTimeMinutes;
    public Text RaceTimeSeconds;
    public Text BestLapTimeMinutes;
    public Text BestLapTimeSeconds;
    public Text CheckPointTime;
    public Text WrongWayT;
    public Text TotalCarsText;
    public Text PlayersPosition;
    public GameObject CheckPointDisplay;
    public GameObject NewLapRecord;
    public GameObject WrongWayText;
    public GameObject WrongWayImage;
    public GameObject CorrectWayImage;

    private int TotalLaps;
    private int TotalCars;
    public bool RaceTrack = true;

    public GameObject F1Opponent1;
    public GameObject F1Opponent2;
    public GameObject F1Opponent3;
    public GameObject F1Opponent4;
    public GameObject F1Opponent5;
    public GameObject F1Opponent6;
    public GameObject F1Opponent7;
    // Start is called before the first frame update
    void Start()
    {
        TotalLaps = UniversalSave.LapCounts;
        TotalCars = UniversalSave.OpponentCounts + 1;
        SpeedRing.fillAmount = 0;
        SpeedText.text = "0";
        GearText.text = "N";
        TypeSpeedText.text = "KPH";
        LapNumberText.text = "0";
        TotalLapsText.text = "/" + TotalLaps.ToString();
        CheckPointDisplay.SetActive(false);
        NewLapRecord.SetActive(false);
        WrongWayText.SetActive(false);
        WrongWayImage.SetActive(false);
        SaveScript.MaxLaps = TotalLaps;
        TotalCarsText.text = "/" + TotalCars.ToString();
        PlayersPosition.text = "1";
        if (RaceTrack == true)
        {
            SetCarVisibility();
        }
    }
    void SetCarVisibility()
    {
        if (TotalCars == 2)
        {
            F1Opponent1.SetActive(true);
            F1Opponent2.SetActive(false);
            F1Opponent3.SetActive(false);
            F1Opponent4.SetActive(false);
            F1Opponent5.SetActive(false);
            F1Opponent6.SetActive(false);
            F1Opponent7.SetActive(false);
        }

        if (TotalCars == 3)
        {
            F1Opponent1.SetActive(true);
            F1Opponent2.SetActive(true);
            F1Opponent3.SetActive(false);
            F1Opponent4.SetActive(false);
            F1Opponent5.SetActive(false);
            F1Opponent6.SetActive(false);
            F1Opponent7.SetActive(false);
        }
        if (TotalCars == 4)
        {
            F1Opponent1.SetActive(true);
            F1Opponent2.SetActive(true);
            F1Opponent3.SetActive(true);
            F1Opponent4.SetActive(false);
            F1Opponent5.SetActive(false);
            F1Opponent6.SetActive(false);
            F1Opponent7.SetActive(false);
        }
        if (TotalCars == 5)
        {
            F1Opponent1.SetActive(true);
            F1Opponent2.SetActive(true);
            F1Opponent3.SetActive(true);
            F1Opponent4.SetActive(true);
            F1Opponent5.SetActive(false);
            F1Opponent6.SetActive(false);
            F1Opponent7.SetActive(false);
        }
        if (TotalCars == 6)
        {
            F1Opponent1.SetActive(true);
            F1Opponent2.SetActive(true);
            F1Opponent3.SetActive(true);
            F1Opponent4.SetActive(true);
            F1Opponent5.SetActive(true);
            F1Opponent6.SetActive(false);
            F1Opponent7.SetActive(false);
        }
        if (TotalCars == 7)
        {
            F1Opponent1.SetActive(true);
            F1Opponent2.SetActive(true);
            F1Opponent3.SetActive(true);
            F1Opponent4.SetActive(true);
            F1Opponent5.SetActive(true);
            F1Opponent6.SetActive(true);
            F1Opponent7.SetActive(false);
        }
        if (TotalCars == 8)
        {
            F1Opponent1.SetActive(true);
            F1Opponent2.SetActive(true);
            F1Opponent3.SetActive(true);
            F1Opponent4.SetActive(true);
            F1Opponent5.SetActive(true);
            F1Opponent6.SetActive(true);
            F1Opponent7.SetActive(true);
        }
    }

        // Update is called once per frame
        void Update()
    {
        //Speedometer
        DisplaySpeed = SaveScript.speed / SaveScript.Topspeed;
        SpeedRing.fillAmount = DisplaySpeed;
        SpeedText.text = (Mathf.Round(SaveScript.speed).ToString());
        if (SaveScript.Gear == -1)
        {
            GearText.text = "R";
        }
        else
        {
            GearText.text = SaveScript.Gear.ToString();
        }
        TypeSpeedText.text = SaveScript.typeSpeed;

        LapNumberText.text = (SaveScript.LapNumber).ToString();

        //Laptime
        if (SaveScript.LapTimeMinutes <= 9)
        {
            LapTimeMinutes.text = "0" + (Mathf.Round(SaveScript.LapTimeMinutes).ToString()) + ":";
        }
        else if (SaveScript.LapTimeMinutes >= 10)
        {
            LapTimeMinutes.text = (Mathf.Round(SaveScript.LapTimeMinutes).ToString()) + ":";
        }
        if (SaveScript.LapTimeSeconds <= 9)
        {
            LapTimeSeconds.text = "0" + (Mathf.Round(SaveScript.LapTimeSeconds).ToString());
        }
        else if (SaveScript.LapTimeSeconds >= 10)
        {
            LapTimeSeconds.text = (Mathf.Round(SaveScript.LapTimeSeconds).ToString());
        }

        //RaceTime
        if (SaveScript.RaceTimeMinutes <= 9)
        {
            RaceTimeMinutes.text = "0" + (Mathf.Round(SaveScript.RaceTimeMinutes).ToString()) + ":";
        }
        else if (SaveScript.RaceTimeMinutes >= 10)
        {
            RaceTimeMinutes.text = (Mathf.Round(SaveScript.RaceTimeMinutes).ToString()) + ":";
        }
        if (SaveScript.RaceTimeSeconds <= 9)
        {
            RaceTimeSeconds.text = "0" + (Mathf.Round(SaveScript.RaceTimeSeconds).ToString());
        }
        else if (SaveScript.RaceTimeSeconds >= 10)
        {
            RaceTimeSeconds.text = (Mathf.Round(SaveScript.RaceTimeSeconds).ToString());
        }

        //working out best laptime
        if (SaveScript.LapChange == true)
        {

            if (SaveScript.LastLapMinutes == SaveScript.BestLapTimeMinutes)
            {
                if (SaveScript.LastLapSeconds < SaveScript.BestLapTimeSeconds)
                {
                    SaveScript.BestLapTimeSeconds = SaveScript.LastLapSeconds;
                    SaveScript.NewRecord = true;
                }
            }
            if (SaveScript.LastLapMinutes < SaveScript.BestLapTimeMinutes)
            {
                SaveScript.BestLapTimeMinutes = SaveScript.LastLapMinutes;
                SaveScript.BestLapTimeSeconds = SaveScript.LastLapSeconds;
                SaveScript.NewRecord = true;
            }
        }

        //Display Best Lap Time
        if (SaveScript.BestLapTimeMinutes <= 9)
        {
            BestLapTimeMinutes.text = "0" + (Mathf.Round(SaveScript.BestLapTimeMinutes).ToString()) + ":";
        }
        else if (SaveScript.BestLapTimeMinutes >= 10)
        {
            BestLapTimeMinutes.text = (Mathf.Round(SaveScript.BestLapTimeMinutes).ToString()) + ":";
        }
        if (SaveScript.BestLapTimeSeconds <= 9)
        {
            BestLapTimeSeconds.text = "0" + (Mathf.Round(SaveScript.BestLapTimeSeconds).ToString());
        }
        else if (SaveScript.RaceTimeSeconds >= 10)
        {
            BestLapTimeSeconds.text = (Mathf.Round(SaveScript.BestLapTimeSeconds).ToString());
        }

        //CheckPoint working out for checkpoint 1
        if(SaveScript.CheckPointPass1 == true)
        {
            SaveScript.CheckPointPass1 = false;
            if (SaveScript.LapNumber > 1)
            {
                CheckPointDisplay.SetActive(true);
                if (SaveScript.ThisCheckPoint1 > SaveScript.LastCheckPoint1)
                {
                    CheckPointTime.color = Color.red;
                    CheckPointTime.text = "-" + (SaveScript.ThisCheckPoint1 - SaveScript.LastCheckPoint1).ToString();
                    StartCoroutine(CheckPointOff());
                }
                if (SaveScript.ThisCheckPoint1 < SaveScript.LastCheckPoint1)
                {
                    CheckPointTime.color = Color.green;
                    CheckPointTime.text = "+" + (SaveScript.LastCheckPoint1 - SaveScript.ThisCheckPoint1).ToString();
                    StartCoroutine(CheckPointOff());
                }
            }
        }
        //CheckPoint working out for checkpoint 2
        if (SaveScript.CheckPointPass2 == true)
        {
            SaveScript.CheckPointPass2 = false;
            if (SaveScript.LapNumber > 1)
            {
                CheckPointDisplay.SetActive(true);
                if (SaveScript.ThisCheckPoint2 > SaveScript.LastCheckPoint2)
                {
                    CheckPointTime.color = Color.red;
                    CheckPointTime.text = "-" + (SaveScript.ThisCheckPoint2 - SaveScript.LastCheckPoint2).ToString();
                    StartCoroutine(CheckPointOff());
                }
                if (SaveScript.ThisCheckPoint2 < SaveScript.LastCheckPoint2)
                {
                    CheckPointTime.color = Color.green;
                    CheckPointTime.text = "+" + (SaveScript.LastCheckPoint2 - SaveScript.ThisCheckPoint2).ToString();
                    StartCoroutine(CheckPointOff());
                }
            }
        }

        //wrong way message
        if(SaveScript.WrongWay == true) 
        {
            WrongWayText.SetActive(true);
            WrongWayImage.SetActive(true);
        }
        if (SaveScript.WrongWay == false)
        {
            WrongWayText.SetActive(false);
            WrongWayImage.SetActive(false);
        }
        //wrong way reset
        if(SaveScript.WWTextReset == false) 
        {
            WrongWayT.text = "WRONG WAY!";
        }
        if(SaveScript.WWTextReset == true)
        {
            WrongWayT.text = " ";            
        }
        if (SaveScript.RaceStart == true && SaveScript.WrongWay == false)
        {            
            StartCoroutine(CheckCorrectWay());
        }

        //Display Position
        PlayersPosition.text = SaveScript.PlayerPosition.ToString();
    }
    IEnumerator CheckCorrectWay()
    {
        yield return new WaitForSeconds(3f);
        CorrectWayImage.SetActive(false);
    }
    IEnumerator CheckPointOff()
    {
        yield return new WaitForSeconds(2);
        CheckPointDisplay.SetActive(false);
    }
}
