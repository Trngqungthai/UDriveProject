using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceType : MonoBehaviour
{
    public bool TimeTrial = true;
    public float GoldMinutes;
    public float GoldSeconds;
    public float SilverMinutes;
    public float SilveSeconds; 
    public float BronzeMinutes;
    public float BronzeSeconds;
    // Start is called before the first frame update
    void Start()
    {
        if (TimeTrial == true)
        {
            SaveScript.TimeTrialMinG = GoldMinutes * UniversalSave.LapCounts;
            SaveScript.TimeTrialSecondsG = GoldSeconds * UniversalSave.LapCounts;
            SaveScript.TimeTrialMinS = SilverMinutes * UniversalSave.LapCounts;
            SaveScript.TimeTrialSecondsS = SilveSeconds * UniversalSave.LapCounts;
            SaveScript.TimeTrialMinB = BronzeMinutes * UniversalSave.LapCounts;
            SaveScript.TimeTrialSecondsB = BronzeSeconds * UniversalSave.LapCounts;            
        }       
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.TimeTrialSecondsG >= 60)
        {
            SaveScript.TimeTrialSecondsG -= 60;
            SaveScript.TimeTrialMinG = SaveScript.TimeTrialMinG + 1;
        }
        if (SaveScript.TimeTrialSecondsS >= 60)
        {
            SaveScript.TimeTrialSecondsS -= 60;
            SaveScript.TimeTrialMinS = SaveScript.TimeTrialMinS + 1;
        }
        if (SaveScript.TimeTrialSecondsB >= 60)
        {
            SaveScript.TimeTrialSecondsB -= 60;
            SaveScript.TimeTrialMinB = SaveScript.TimeTrialMinB + 1;
        }
        if (SaveScript.RaceOver == true)
        {
            if (TimeTrial == true)
            {
                if (SaveScript.RaceTimeMinutes < GoldMinutes)
                {
                    //Debug.Log("Gold");
                    SaveScript.Gold = true;
                }
                if (SaveScript.RaceTimeMinutes == GoldMinutes && (SaveScript.RaceTimeSeconds + SaveScript.PenaltySeconds) < GoldSeconds)
                {
                    //Debug.Log("Gold");
                    SaveScript.Gold = true;
                }

                if (SaveScript.RaceTimeMinutes < SilverMinutes)
                {
                    if (SaveScript.Gold == false)
                    {
                        //Debug.Log("Silver");
                        SaveScript.Silver = true;
                    }
                }
                if (SaveScript.RaceTimeMinutes == SilverMinutes && (SaveScript.RaceTimeSeconds + SaveScript.PenaltySeconds) < SilveSeconds)
                {
                    if (SaveScript.Gold == false)
                    {
                        //Debug.Log("Silver");
                        SaveScript.Silver = true;
                    }
                }

                if (SaveScript.RaceTimeMinutes < BronzeMinutes)
                {
                    if (SaveScript.Gold == false && SaveScript.Silver == false)
                    {
                        //Debug.Log("Bronze");
                        SaveScript.Bronze = true;
                    }
                }
                if (SaveScript.RaceTimeMinutes == BronzeMinutes && (SaveScript.RaceTimeSeconds + SaveScript.PenaltySeconds) < BronzeSeconds)
                {
                    if (SaveScript.Gold == false && SaveScript.Silver == false)
                    {
                        //Debug.Log("Bronze");
                        SaveScript.Bronze = true;
                    }
                }
                else if (SaveScript.Gold == false && SaveScript.Silver == false && SaveScript.Bronze == false)
                {
                    //Debug.Log("Fail");
                    SaveScript.Fail = true;
                }
            }
        }
    }
}
