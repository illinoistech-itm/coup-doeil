using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour {
    public Transform[] wayPointList;
    public int currentWayPoint = 0;
    Transform targetWayPoint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Walk(float speed)
    {
        if (this.wayPointList.Length > 0) {
            if (currentWayPoint < this.wayPointList.Length)
            {
                targetWayPoint = wayPointList[currentWayPoint];
            }
            else
            {
                currentWayPoint = 0;
                targetWayPoint = wayPointList[currentWayPoint];
            }
         
            transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

            if (transform.position == targetWayPoint.position)
            {
                currentWayPoint++;
            }
        }
    }
}
