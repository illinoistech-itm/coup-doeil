using UnityEngine;

public class UIController : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
        RotateUI();
    }

    private void RotateUI()
    {
        GameObject[] menus = GameObject.FindGameObjectsWithTag("UIMenu");
        foreach (GameObject menu in menus)
        {
            menu.transform.LookAt(Camera.main.transform);
            menu.transform.RotateAround(menu.transform.position, menu.transform.up, 180f);
        }
    }
}
