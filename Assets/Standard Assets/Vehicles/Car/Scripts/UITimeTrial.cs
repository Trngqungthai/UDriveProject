using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeTrial : MonoBehaviour
{
    public Text TimeTrialMinutesG;
    public Text TimeTrialSecondsG;
    public Text TimeTrialMinutesS;
    public Text TimeTrialSecondsS;
    public Text TimeTrialMinutesB;
    public Text TimeTrialSecondsB;
    public Text WinMessege;
    public GameObject TimeTrialObject;
    public GameObject TimeTrialResults;
    public GameObject GoldStar;
    public GameObject SilverStar;
    public GameObject BronzeStar;
    public GameObject UISpeed;
    public GameObject OverUI;
    private bool Winner = false;
    void Start()
    {
        TimeTrialObject.SetActive(true);
        TimeTrialResults.SetActive(false);
        OverUI.SetActive(false);
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.RaceOver == false)
        {
            //Setting The Timetrial Gold Time
            if (SaveScript.TimeTrialMinG <= 9)
            {
                TimeTrialMinutesG.text = "0" + SaveScript.TimeTrialMinG.ToString() + ":";
            }
            if (SaveScript.TimeTrialMinG >= 10)
            {
                TimeTrialMinutesG.text = SaveScript.TimeTrialMinG.ToString() + ":";
            }
            if (SaveScript.TimeTrialSecondsG <= 9)
            {
                TimeTrialSecondsG.text = "0" + SaveScript.TimeTrialSecondsG.ToString();
            }
            if (SaveScript.TimeTrialSecondsG >= 10)
            {
                TimeTrialSecondsG.text = SaveScript.TimeTrialSecondsG.ToString();
            }
            //Setting The Timetrial Silver Time
            if (SaveScript.TimeTrialMinS <= 9)
            {
                TimeTrialMinutesS.text = "0" + SaveScript.TimeTrialMinS.ToString() + ":";
            }
            if (SaveScript.TimeTrialMinS >= 10)
            {
                TimeTrialMinutesS.text = SaveScript.TimeTrialMinS.ToString() + ":";
            }
            if (SaveScript.TimeTrialSecondsS <= 9)
            {
                TimeTrialSecondsS.text = "0" + SaveScript.TimeTrialSecondsS.ToString();
            }
            if (SaveScript.TimeTrialSecondsS >= 10)
            {
                TimeTrialSecondsS.text = SaveScript.TimeTrialSecondsS.ToString();
            }
            //Setting The Timetrial Bronze Time
            if (SaveScript.TimeTrialMinB <= 9)
            {
                TimeTrialMinutesB.text = "0" + SaveScript.TimeTrialMinB.ToString() + ":";
            }
            if (SaveScript.TimeTrialMinB >= 10)
            {
                TimeTrialMinutesB.text = SaveScript.TimeTrialMinB.ToString() + ":";
            }
            if (SaveScript.TimeTrialSecondsB <= 9)
            {
                TimeTrialSecondsB.text = "0" + SaveScript.TimeTrialSecondsB.ToString();
            }
            if (SaveScript.TimeTrialSecondsB >= 10)
            {
                TimeTrialSecondsB.text = SaveScript.TimeTrialSecondsB.ToString();
            }
            
        }
        if (SaveScript.RaceOver == true)
        {
            if (Winner == false)
            {
                Winner = true;
                StartCoroutine(WinDisplay());
            }
        }
        IEnumerator WinDisplay()
        {
            yield return new WaitForSeconds(0.1f);
            TimeTrialResults.SetActive(true);
            UISpeed.SetActive(false);
            if (SaveScript.Gold == true)
            {
                WinMessege.text = "YOU WON GOLD";
                GoldStar.SetActive(true);
                OverUI.SetActive(true);
            }
            if (SaveScript.Silver == true)
            {
                WinMessege.text = "YOU WON SILVER";
                SilverStar.SetActive(true);
                OverUI.SetActive(true);
            }
            if (SaveScript.Bronze == true)
            {
                WinMessege.text = "YOU WON BRONZE";
                BronzeStar.SetActive(true);
                OverUI.SetActive(true);
            }
            if (SaveScript.Fail == true)
            {
                WinMessege.text = "TRY AGAIN";
                OverUI.SetActive(true);
            }
        }
    }
}
