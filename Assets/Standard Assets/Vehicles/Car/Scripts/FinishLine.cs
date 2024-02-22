using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject Leaderboard;
    public GameObject ButtonContinue;
    public string PlayerName;
    public static int PlayerFinishPosition;
    public static string PName;

    private void Start()
    {
        PName = PlayerName;
        Leaderboard.SetActive(false);
        ButtonContinue.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SaveScript.FinishPositionID++;
            PlayerFinishPosition = SaveScript.FinishPositionID;
            SaveScript.RaceOver = true;
            Leaderboard.SetActive(true);
            Time.timeScale = 0.5f;
            StartCoroutine(ShowContinue());
        }
    }
    IEnumerator ShowContinue()
    {
        yield return new WaitForSeconds(0.5f);
        ButtonContinue.SetActive(true);
    }
}
