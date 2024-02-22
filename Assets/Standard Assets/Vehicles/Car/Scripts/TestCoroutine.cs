using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutine : MonoBehaviour
{
    [SerializeField] private Material Body;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(enumerator());
    }
    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
        Body.color = Color.red;
    }
    IEnumerator enumerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Body.color = Color.green;
            yield return new WaitForSeconds(0.1f);
            Body.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            Body.color = Color.yellow;
        }
    }
}
