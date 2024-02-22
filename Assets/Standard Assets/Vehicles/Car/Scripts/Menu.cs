using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject ShowroomUI;
    public GameObject ShowroomArt;
    public GameObject UIRace;
    public GameObject RaceTrack;
    public GameObject PlayGame1;
    public GameObject PlayGame2;
    public Camera CameraShowroom;
    public Transform positionCamera1;
    public Transform positionCamera2;
    private Vector3 potsition1;
    private Vector3 potsition2;    
    private float timer;
    private bool isMoving;
    private void Start()
    {
        MenuUI.SetActive(true);
        ShowroomUI.SetActive(false);
        UIRace.SetActive(false);
        RaceTrack.SetActive(false);
        PlayGame1.SetActive(false);
        PlayGame2.SetActive(false);
    }
    private void Update()
    {
        Showroom();
    }
    private void Showroom()
    {
        if (isMoving)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / 2f);
            CameraShowroom.transform.position = Vector3.Lerp(potsition1, potsition2, t);
            if (t >= 1f)
            {
                isMoving = false;
            }
        }
    }    
    public void OnShowroom()
    {
        MenuUI.SetActive(false);
        UIRace.SetActive(false);
        ShowroomUI.SetActive(true);
        potsition1 = positionCamera1.transform.position;
        potsition2 = positionCamera2.transform.position;
        timer = 0f;
        isMoving = true;
    }
    public void OnMenu()
    {
        MenuUI.SetActive(true);
        UIRace.SetActive(false);
        ShowroomUI.SetActive(false);
        potsition2 = positionCamera1.transform.position;
        potsition1 = positionCamera2.transform.position;
        timer = 0f;
        isMoving = true;
    }    
    public void OnRaceTrack()
    {
        MenuUI.SetActive(false);
        ShowroomUI.SetActive(false);
        UIRace.SetActive(true);
        RaceTrack.SetActive(true);
        PlayGame1.SetActive(false); 
        PlayGame2.SetActive(false);
    }    
    public void OnRace1()
    {
        RaceTrack.SetActive(false);
        PlayGame1.SetActive(true);
        PlayGame2.SetActive(false);
    }
    public void OnRace2()
    {
        RaceTrack.SetActive(false);
        PlayGame1.SetActive(false);
        PlayGame2.SetActive(true);
    }
}
