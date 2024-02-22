using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLightsScript : MonoBehaviour
{
    public GameObject RedLightOff;
    public GameObject RedLightOn;
    public GameObject AmberLightOff;
    public GameObject AmberLightOn;
    public GameObject GreenLightOff;
    public GameObject GreenLightOn;
    public AudioSource Sound1;
    public AudioSource Sound2;
    public GameObject Go;
    // Start is called before the first frame update
    void Start()
    {
        if (SaveScript.RaceOver == false)
        {
            Go.SetActive(false);
            StartCoroutine(StartingLights());
        }
    }
    IEnumerator StartingLights()
    {
        yield return new WaitForSeconds(1f);
        RedLightOff.SetActive(false); 
        RedLightOn.SetActive(true);
        Sound1.Play();
        yield return new WaitForSeconds(1f);
        RedLightOff.SetActive(true);
        RedLightOn.SetActive(false);
        Sound1.Play();
        AmberLightOff.SetActive(false);
        AmberLightOn.SetActive(true); 
        yield return new WaitForSeconds(1f);
        AmberLightOff.SetActive(true);
        AmberLightOn.SetActive(false);
        Sound2.Play();
        GreenLightOff.SetActive(false);
        GreenLightOn.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SaveScript.RaceStart = true;
        Go.SetActive(true);
        yield return new WaitForSeconds(2f);
        Go.SetActive(false);
    }
}
