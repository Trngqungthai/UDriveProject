using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemChecker : MonoBehaviour
{
    void Awake()
    {
        if (!FindObjectOfType<EventSystem>())
        {
            GameObject eventSystemObj = new GameObject("EventSystem");
            eventSystemObj.AddComponent<EventSystem>();
            eventSystemObj.AddComponent<StandaloneInputModule>();
        }
    }
}