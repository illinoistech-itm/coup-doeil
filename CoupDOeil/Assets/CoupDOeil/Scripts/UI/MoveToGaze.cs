using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveToGaze : MonoBehaviour, IInputClickHandler
{
    public bool moving = false;

    private SpatialMappingManager spatialMappingManager;

    // Use this for initialization
    void Start()
    {
        spatialMappingManager = SpatialMappingManager.Instance;
        if (spatialMappingManager == null)
        {
            Debug.LogError("This script expects that you have a SpatialMappingManager component in your scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                30.0f, spatialMappingManager.LayerMask))
            {
                // Move this object to where the raycast
                // hit the Spatial Mapping mesh.
                // Here is where you might consider adding intelligence
                // to how the object is placed.  For example, consider
                // placing based on the bottom of the object's
                // collider so it sits properly on surfaces.
                this.transform.position = hitInfo.point + new Vector3(0f, 0.02f, 0f);

                // Rotate this object to face the user.
                /*Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;
                this.transform.rotation = toQuat;*/
            }
            else
            {
                Debug.LogError("Error, not hitted point");
            }
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Clicked");
        stopMoving();
    }


    internal void startMoving()
    {
        moving = true;
    }

    internal void stopMoving()
    {
        moving = false;
    }
}
