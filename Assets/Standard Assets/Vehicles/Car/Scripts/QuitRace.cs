using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitRace : MonoBehaviour
{
    public GameObject QuitPanel;
    private void Start()
    {
        QuitPanel.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            QuitPanel.SetActive(true);
        }
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu+Showroom");
    }
    public void QuitClose()
    {
        QuitPanel.SetActive(false);
    }
}
