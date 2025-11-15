using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer;
    public Action action;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Wait(StateManager state)
    {
    StartCoroutine(WaitTime(state));
    }

IEnumerator WaitTime(StateManager state)
    {
        yield return new WaitForSeconds(2);
        state.transform.GetChild(0).gameObject.SetActive(false);
    }
}
