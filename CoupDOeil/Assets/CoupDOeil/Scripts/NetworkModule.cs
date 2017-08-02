using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkModule
{
    private string host = "http://13.59.155.171/"; //AWS connection 
    private string googleAPIToken = "AIzaSyCM0HdInkiDU-x4U4tHpksUd6Y4TNXQw9g";

    public IEnumerator GetTexture(float lat, float lon, int zoom, Action<Texture> callback)
    {
        Texture res = null;
        String img = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon + "&zoom=" + zoom + "&size=600x600&maptype=satellite&key=" + googleAPIToken;

        UnityWebRequest www = UnityWebRequest.GetTexture(img, false);
        yield return www.Send();
        while (!www.isDone)
        {
            Debug.LogError(".");
            yield return null;
        }
        if (www.isError)
        {
            Debug.Log("ERR HL: " + www.error);
        }
        else
        {
            res = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
        callback(res);
    }

    public IEnumerator GetDrones(Action<string> callback)
    {
        string json = null;
        
        WWW www = new WWW(host + "drone");
        yield return www;
        if (www.error == null)
        {
            json = www.text;
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }

        callback(json);
    }

    public IEnumerator GetDrone(int id, int? from, int? to, int? limit, Action<string> callback)
    {
        string json = null;
        string url = host + "drone/" + id;

        if (from != null || to != null || limit != null)
        {
            url += "?";
            if (from != null)
            {
                url += "from=" + from + "&";
            }
            if (to != null)
            {
                url += "to=" + to + "&";
            }
            if (limit != null)
            {
                url += "limit=" + limit;
            }
        }
        
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            json = www.text;
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }

        callback(json);
    }
}
