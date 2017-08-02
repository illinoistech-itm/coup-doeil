using UnityEngine;

public class CameraRotation : MonoBehaviour {

    public float angle = 180f;
    
	void Start () {
		
	}
	
	void Update () {
        Rotate();
    }

    private void Rotate()
    {
        transform.LookAt(Camera.main.transform);
        transform.RotateAround(transform.position, transform.up, angle);
    }
}
