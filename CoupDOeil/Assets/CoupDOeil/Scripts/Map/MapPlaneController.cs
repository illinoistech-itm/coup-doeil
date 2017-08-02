using System;
using System.Collections;
using UnityEngine;

public class MapPlaneController : MonoBehaviour {

    private bool chasing = false;
    private float fakeAltitude = 40.714728f;
    private int followZoom = 17;
    
    void Start () {}
	
	void Update () {}


    public void downloadMapTexture(NetworkModule nm, float lat, float lon, int zoom)
    {
        StartCoroutine(nm.GetTexture(lat, lon, zoom, (texture) =>
        {
            if(texture != null)
            {
                GetComponent<Renderer>().materials[0].mainTexture = texture;
            }
        }));
    }

    /*
     * Map Module
     * 
     */
    public void startMapMode(NetworkModule networkModule, bool fakeData)
    {
        if (fakeData)
        {
            downloadMapTexture(networkModule, 40.714728f, -73.998672f, 13);
        }
        else StartCoroutine(MappingRoutine(networkModule));
    }

    private IEnumerator MappingRoutine(NetworkModule networkModule)
    {
        throw new NotImplementedException();
    }

    /*
     *  Chasing module
     * 
     */
    public void startChasing(int id, NetworkModule networkModule, bool fakeData)
    {
        chasing = true;
        if (fakeData) StartCoroutine(FollowRoutineFake(networkModule));
        else StartCoroutine(FollowRoutine(id, networkModule));
    }

    public void stopChasing()
    {
        chasing = false;
    }

    IEnumerator FollowRoutineFake(NetworkModule networkModule)
    {
        while (chasing)
        {
            downloadMapTexture(networkModule, fakeAltitude, -73.998672f, followZoom);
            fakeAltitude += 0.00001f;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator FollowRoutine(int id, NetworkModule networkModule)
    {
        int lastTime = 0;
        while (chasing)
        {
            StartCoroutine(networkModule.GetDrone(id, lastTime, null, 1, (info) =>
                {
                    if (info != null)
                    {
                        string jsonFree = info.Remove(0, 1);
                        jsonFree = jsonFree.Remove(jsonFree.Length - 1, 1);
                        
                        if (jsonFree.Length > 0)
                        {
                            DroneData drone_data = JsonUtility.FromJson<DroneData>(jsonFree);
                            lastTime = drone_data.timestamp;
                            downloadMapTexture(networkModule, drone_data.latitude, drone_data.longitude, followZoom);
                        }
                    }
                })
            );
            yield return new WaitForSeconds(2);
        }
    }
}
