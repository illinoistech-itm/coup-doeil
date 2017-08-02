using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class FixObjectInFront : MonoBehaviour, IInputClickHandler
{

    public bool placing = true;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        placing = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (placing)
        {
            Vector3 headPosition = Camera.main.transform.position;
            Vector3 gazeDirection = Camera.main.transform.forward;

            this.transform.position = headPosition + gazeDirection * 2;

        }
    }
}
