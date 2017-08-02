using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(Camera.main.transform);
        gameObject.transform.Rotate(Vector3.up, 180f);
		
	}
}
