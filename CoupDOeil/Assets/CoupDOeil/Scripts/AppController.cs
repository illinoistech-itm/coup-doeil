using UnityEngine;

public enum Modes
{
    ModeRtm, ModeMp, ModeCD, ModeFree
}

public class AppController : MonoBehaviour {

    public GameObject terrain;
    public GameObject map;
    public GameObject chasedDrone;
    public GameObject[] drones;

    public float speed = 4f;
    public bool fakeData = false;
    public Modes enabledMode = Modes.ModeCD;

    private NetworkModule networkModule = new NetworkModule();

    public void ChangeMode(Modes newMode)
    {
        if(enabledMode != newMode)
        {
            enabledMode = newMode;
            CheckMode();
        }
    }

    private void CheckMode()
    {
        if(terrain != null)
            terrain.gameObject.SetActive(false);
        if (map != null)
        {
            map.gameObject.SetActive(false);
            map.GetComponent<MapPlaneController>().stopChasing();
        }
        ShowDrones();

        if (enabledMode == Modes.ModeRtm)
        {
            loadTerrainMode();
        }
        else if (enabledMode == Modes.ModeMp)
        {
            loadMapsMode();
        }
        else if (enabledMode == Modes.ModeCD)
        {
            loadChasingMode();
        }
    }

    private void ShowDrones()
    {
        foreach (GameObject drone in drones)
        {
            drone.SetActive(true);
        }

        chasedDrone.SetActive(false);
    }

    private void ShowChased()
    {
        foreach (GameObject drone in drones)
        {
            drone.SetActive(false);
        }
        chasedDrone.SetActive(true);
    }


    private void loadTerrainMode()
    {
        terrain.gameObject.SetActive(true);
    }

    private void loadMapsMode()
    {
        map.gameObject.SetActive(true);

        map.GetComponent<MapPlaneController>().startMapMode(networkModule, fakeData);
    }

    private void loadChasingMode()
    {
        map.gameObject.SetActive(true);
        ShowChased();

        map.GetComponent<MapPlaneController>().startChasing(21, networkModule, fakeData);
    }

    private void MoveDrones()
    {
        GameObject[] drones = GameObject.FindGameObjectsWithTag("Drone");
        foreach (GameObject drone in drones)
        {
            if (drone.activeSelf) { 
                DroneScript ds = drone.GetComponent<DroneScript>();
                if (ds != null)
                    ds.Walk(speed);
            }
        }
    }

    void Start()
    {
        StartCoroutine(networkModule.GetDrones((result) =>
        {
            print(result);
        }));
        CheckMode();
    }

    void Update()
    {
        MoveDrones();
    }
}
