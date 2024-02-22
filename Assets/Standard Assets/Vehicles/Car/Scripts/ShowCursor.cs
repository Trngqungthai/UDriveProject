using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    private bool isCursorVisible = true;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            isCursorVisible = !isCursorVisible;
            SetCursorVisibility(isCursorVisible);
        }
        if (SaveScript.RaceOver == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void SetCursorVisibility(bool isVisible)
    {
        if (isVisible)
        {
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None; 
        }
        else
        {
            Cursor.visible = false; 
            Cursor.lockState = CursorLockMode.Locked; 
        }
    }
}
