using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRaceTrack : MonoBehaviour
{
    public Text WinMessage;
    public GameObject Leaderboard;
    void Start()
    {
        Leaderboard.SetActive(false);
        if(FinishLine.PlayerFinishPosition == 1)
        {
            WinMessage.text = "1ST PLACE";
        }
        if (FinishLine.PlayerFinishPosition == 2)
        {
            WinMessage.text = "2ND PLACE";
        }
        if (FinishLine.PlayerFinishPosition == 3)
        {
            WinMessage.text = "3RD PLACE";
        }
        if (FinishLine.PlayerFinishPosition > 3)
        {
            WinMessage.text = FinishLine.PlayerFinishPosition + "TH PLACE";
        }

    }
    public void DisplayLeaderboard()
    {
        Leaderboard.SetActive(true);
        this.gameObject.SetActive(false);
        Time.timeScale = 0;
    } 
}
