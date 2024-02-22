using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverUIScript : MonoBehaviour
{
    public GameObject Leaderboard;
    public GameObject Results;
    private void Start()
    {
        Results.SetActive(false);
    }
    public void ReloadGame()
    {
        StartCoroutine(WaitToLoad());
    }
    public void BackMenuGame()
    {
        SceneManager.LoadScene("Menu+ShowRoom");
    }
    public void Continue()
    {
        Results.SetActive(true);
        Leaderboard.SetActive(false);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SaveScript.RaceOver = false;
        SaveScript.RaceStart = false;
    }
}
