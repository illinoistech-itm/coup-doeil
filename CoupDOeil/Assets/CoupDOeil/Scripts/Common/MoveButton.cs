using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveButton : MonoBehaviour, IInputClickHandler
{
    public GameObject controller;
    public bool enableStopTimer = false;
    public int stopTimer = 4;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        controller.GetComponent<MoveToGaze>().startMoving();
        if (enableStopTimer) StartCoroutine(stopMoving());
    }

    IEnumerator stopMoving()
    {
        yield return new WaitForSeconds(stopTimer);
        controller.GetComponent<MoveToGaze>().stopMoving();
    }
}
