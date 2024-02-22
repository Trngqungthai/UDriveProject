using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressWaypoints : MonoBehaviour
{
    public int WPNumber;
    public int CarTracking = 0;
    public int DirectionTracking = 0;
    public bool PenaltyOption = false;
    public int PenaltyWayPoint;
    public int Position = 0;

    private int Lap1Position = 0;
    private int Lap2Position = 0;
    private int Lap3Position = 0;
    private int Lap4Position = 0;
    private int Lap5Position = 0;
    private int Lap6Position = 0;
    private int Lap7Position = 0;
    private int Lap8Position = 0;
    private int Lap9Position = 0;
    private int Lap10Position = 0;
    private int Lap11Position = 0;
    private int Lap12Position = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Progress"))
        {
            CarTracking = other.GetComponent<ProgressTracker>().CurrentWP;
            if(CarTracking < WPNumber)
            {
                other.GetComponent<ProgressTracker>().CurrentWP = WPNumber;
                if(SaveScript.LapNumber == 1)
                {
                    Lap1Position++;
                    SaveScript.PlayerPosition = Lap1Position;
                }
                if (SaveScript.LapNumber == 2)
                {
                    Lap2Position++;
                    SaveScript.PlayerPosition = Lap2Position;
                }
                if (SaveScript.LapNumber == 3)
                {
                    Lap3Position++;
                    SaveScript.PlayerPosition = Lap3Position;
                }
                if (SaveScript.LapNumber == 4)
                {
                    Lap4Position++;
                    SaveScript.PlayerPosition = Lap4Position;
                }
                if (SaveScript.LapNumber == 5)
                {
                    Lap5Position++;
                    SaveScript.PlayerPosition = Lap5Position;
                }
                if (SaveScript.LapNumber == 6)
                {
                    Lap6Position++;
                    SaveScript.PlayerPosition = Lap6Position;
                }
                if (SaveScript.LapNumber == 7)
                {
                    Lap7Position++;
                    SaveScript.PlayerPosition = Lap7Position;
                }
                if (SaveScript.LapNumber == 8)
                {
                    Lap8Position++;
                    SaveScript.PlayerPosition = Lap8Position;
                }
                if (SaveScript.LapNumber == 9)
                {
                    Lap9Position++;
                    SaveScript.PlayerPosition = Lap9Position;
                }
                if (SaveScript.LapNumber == 10)
                {
                    Lap10Position++;
                    SaveScript.PlayerPosition = Lap10Position;
                }
                if (SaveScript.LapNumber == 11)
                {
                    Lap11Position++;
                    SaveScript.PlayerPosition = Lap11Position;
                }
                if (SaveScript.LapNumber == 12)
                {
                    Lap12Position++;
                    SaveScript.PlayerPosition = Lap12Position;
                }
            }
            if (CarTracking > WPNumber) 
            {
                other.GetComponent<ProgressTracker>().LastMPNumber = WPNumber;
            }
            if(PenaltyOption == true) 
            {
                if (CarTracking < PenaltyWayPoint) 
                {
                    Debug.Log("Penalty");
                    SaveScript.PenaltySeconds += 5;
                    PenaltyOption = false;
                }
            }
        }
        if(other.gameObject.CompareTag("ProgressAI1"))
        {
            if(SaveScript.AICar1LapNumer == 1)
            {
                Lap1Position++;
            }
            if (SaveScript.AICar1LapNumer == 2)
            {
                Lap2Position++;
            }
            if (SaveScript.AICar1LapNumer == 3)
            {
                Lap3Position++;
            }
            if (SaveScript.AICar1LapNumer == 4)
            {
                Lap4Position++;
            }
            if (SaveScript.AICar1LapNumer == 5)
            {
                Lap5Position++;
            }
            if (SaveScript.AICar1LapNumer == 6)
            {
                Lap6Position++;
            }
            if (SaveScript.AICar1LapNumer == 7)
            {
                Lap7Position++;
            }
            if (SaveScript.AICar1LapNumer == 8)
            {
                Lap8Position++;
            }
            if (SaveScript.AICar1LapNumer == 9)
            {
                Lap9Position++;
            }
            if (SaveScript.AICar1LapNumer == 10)
            {
                Lap10Position++;
            }
            if (SaveScript.AICar1LapNumer == 11)
            {
                Lap11Position++;
            }
            if (SaveScript.AICar1LapNumer == 12)
            {
                Lap12Position++;
            }
        }
        if (other.gameObject.CompareTag("ProgressAI2"))
        {
            if (SaveScript.AICar2LapNumer == 1)
            {
                Lap1Position++;
            }
            if (SaveScript.AICar2LapNumer == 2)
            {
                Lap2Position++;
            }
            if (SaveScript.AICar2LapNumer == 3)
            {
                Lap3Position++;
            }
            if (SaveScript.AICar2LapNumer == 4)
            {
                Lap4Position++;
            }
            if (SaveScript.AICar2LapNumer == 5)
            {
                Lap5Position++;
            }
            if (SaveScript.AICar2LapNumer == 6)
            {
                Lap6Position++;
            }
            if (SaveScript.AICar2LapNumer == 7)
            {
                Lap7Position++;
            }
            if (SaveScript.AICar2LapNumer == 8)
            {
                Lap8Position++;
            }
            if (SaveScript.AICar2LapNumer == 9)
            {
                Lap9Position++;
            }
            if (SaveScript.AICar2LapNumer == 10)
            {
                Lap10Position++;
            }
            if (SaveScript.AICar2LapNumer == 11)
            {
                Lap11Position++;
            }
            if (SaveScript.AICar2LapNumer == 12)
            {
                Lap12Position++;
            }
        }
        if (other.gameObject.CompareTag("ProgressAI3"))
        {
            if (SaveScript.AICar3LapNumer == 1)
            {
                Lap1Position++;
            }
            if (SaveScript.AICar3LapNumer == 2)
            {
                Lap2Position++;
            }
            if (SaveScript.AICar3LapNumer == 3)
            {
                Lap3Position++;
            }
            if (SaveScript.AICar3LapNumer == 4)
            {
                Lap4Position++;
            }
            if (SaveScript.AICar3LapNumer == 5)
            {
                Lap5Position++;
            }
            if (SaveScript.AICar3LapNumer == 6)
            {
                Lap6Position++;
            }
            if (SaveScript.AICar3LapNumer == 7)
            {
                Lap7Position++;
            }
            if (SaveScript.AICar3LapNumer == 8)
            {
                Lap8Position++;
            }
            if (SaveScript.AICar3LapNumer == 9)
            {
                Lap9Position++;
            }
            if (SaveScript.AICar3LapNumer == 10)
            {
                Lap10Position++;
            }
            if (SaveScript.AICar3LapNumer == 11)
            {
                Lap11Position++;
            }
            if (SaveScript.AICar3LapNumer == 12)
            {
                Lap12Position++;
            }
        }
        if (other.gameObject.CompareTag("ProgressAI4"))
        {
            if (SaveScript.AICar4LapNumer == 1)
            {
                Lap1Position++;
            }
            if (SaveScript.AICar4LapNumer == 2)
            {
                Lap2Position++;
            }
            if (SaveScript.AICar4LapNumer == 3)
            {
                Lap3Position++;
            }
            if (SaveScript.AICar4LapNumer == 4)
            {
                Lap4Position++;
            }
            if (SaveScript.AICar4LapNumer == 5)
            {
                Lap5Position++;
            }
            if (SaveScript.AICar4LapNumer == 6)
            {
                Lap6Position++;
            }
            if (SaveScript.AICar4LapNumer == 7)
            {
                Lap7Position++;
            }
            if (SaveScript.AICar4LapNumer == 8)
            {
                Lap8Position++;
            }
            if (SaveScript.AICar4LapNumer == 9)
            {
                Lap9Position++;
            }
            if (SaveScript.AICar4LapNumer == 10)
            {
                Lap10Position++;
            }
            if (SaveScript.AICar2LapNumer == 11)
            {
                Lap11Position++;
            }
            if (SaveScript.AICar4LapNumer == 12)
            {
                Lap12Position++;
            }
        }
        if (other.gameObject.CompareTag("ProgressAI5"))
        {
            if (SaveScript.AICar5LapNumer == 1)
            {
                Lap1Position++;
            }
            if (SaveScript.AICar5LapNumer == 2)
            {
                Lap2Position++;
            }
            if (SaveScript.AICar5LapNumer == 3)
            {
                Lap3Position++;
            }
            if (SaveScript.AICar5LapNumer == 4)
            {
                Lap4Position++;
            }
            if (SaveScript.AICar5LapNumer == 5)
            {
                Lap5Position++;
            }
            if (SaveScript.AICar5LapNumer == 6)
            {
                Lap6Position++;
            }
            if (SaveScript.AICar5LapNumer == 7)
            {
                Lap7Position++;
            }
            if (SaveScript.AICar5LapNumer == 8)
            {
                Lap8Position++;
            }
            if (SaveScript.AICar5LapNumer == 9)
            {
                Lap9Position++;
            }
            if (SaveScript.AICar5LapNumer == 10)
            {
                Lap10Position++;
            }
            if (SaveScript.AICar5LapNumer == 11)
            {
                Lap11Position++;
            }
            if (SaveScript.AICar5LapNumer == 12)
            {
                Lap12Position++;
            }
        }
        if (other.gameObject.CompareTag("ProgressAI6"))
        {
            if (SaveScript.AICar6LapNumer == 1)
            {
                Lap1Position++;
            }
            if (SaveScript.AICar6LapNumer == 2)
            {
                Lap2Position++;
            }
            if (SaveScript.AICar6LapNumer == 3)
            {
                Lap3Position++;
            }
            if (SaveScript.AICar6LapNumer == 4)
            {
                Lap4Position++;
            }
            if (SaveScript.AICar6LapNumer == 5)
            {
                Lap5Position++;
            }
            if (SaveScript.AICar6LapNumer == 6)
            {
                Lap6Position++;
            }
            if (SaveScript.AICar6LapNumer == 7)
            {
                Lap7Position++;
            }
            if (SaveScript.AICar6LapNumer == 8)
            {
                Lap8Position++;
            }
            if (SaveScript.AICar6LapNumer == 9)
            {
                Lap9Position++;
            }
            if (SaveScript.AICar6LapNumer == 10)
            {
                Lap10Position++;
            }
            if (SaveScript.AICar6LapNumer == 11)
            {
                Lap11Position++;
            }
            if (SaveScript.AICar6LapNumer == 12)
            {
                Lap12Position++;
            }
        }
        if (other.gameObject.CompareTag("ProgressAI7"))
        {
            if (SaveScript.AICar7LapNumer == 1)
            {
                Lap1Position++;
            }
            if (SaveScript.AICar7LapNumer == 2)
            {
                Lap2Position++;
            }
            if (SaveScript.AICar7LapNumer == 3)
            {
                Lap3Position++;
            }
            if (SaveScript.AICar7LapNumer == 4)
            {
                Lap4Position++;
            }
            if (SaveScript.AICar7LapNumer == 5)
            {
                Lap5Position++;
            }
            if (SaveScript.AICar7LapNumer == 6)
            {
                Lap6Position++;
            }
            if (SaveScript.AICar7LapNumer == 7)
            {
                Lap7Position++;
            }
            if (SaveScript.AICar7LapNumer == 8)
            {
                Lap8Position++;
            }
            if (SaveScript.AICar7LapNumer == 9)
            {
                Lap9Position++;
            }
            if (SaveScript.AICar7LapNumer == 10)
            {
                Lap10Position++;
            }
            if (SaveScript.AICar7LapNumer == 11)
            {
                Lap11Position++;
            }
            if (SaveScript.AICar7LapNumer == 12)
            {
                Lap12Position++;
            }
        }
    }
}
