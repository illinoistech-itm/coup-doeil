using System.Collections;
using UnityEngine;

public class TerrainController : MonoBehaviour
{

    private void BorderLow()
    {
        TerrainData terrainData = Terrain.activeTerrain.terrainData;
        float[,] hs = terrainData.GetHeights(0, 0, terrainData.heightmapWidth, terrainData.heightmapHeight);

        for (int y = 0; y < terrainData.heightmapWidth; y++)
        {
            for (int x = 0; x < terrainData.heightmapHeight; x++)
            {
                if (y == 0 || x == 0 
                      || y == terrainData.heightmapHeight-1
                      || x == terrainData.heightmapWidth-1) {
                    hs[y, x] = 0f;
                }
            }
        }
        terrainData.SetHeights(0, 0, hs);
    }

    private void TerrainColor()
    {
        TerrainData terrainData = Terrain.activeTerrain.terrainData;
        float[,,] splatmapData = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];

        for (int y = 0; y < terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                // read the height at this location
                float height = terrainData.GetHeight(y, x);

                // determine the mix of textures 1, 2 &amp; 3 to use 
                // (using a vector3, since it can be lerped &amp; normalized)
                Vector4 green = new Vector4(0, 1, 0, 0);
                Vector4 red = new Vector4(1, 0, 0, 0);
                Vector4 blue = new Vector4(0, 0, 1, 0);
                Vector4 yellow = new Vector4(0, 0, 0, 1);

                Vector4 splat = green;
                if (height < 0.15f)
                {
                    splat = Vector4.Lerp(blue, green, height / 0.15f);
                }
                else if (height > 0.30f)
                {
                    splat = Vector4.Lerp(yellow, red, (height - 0.30f) / 0.10f);
                }
                else if (height > 0.20f)
                {
                    splat = Vector4.Lerp(green, yellow, (height - 0.20f) / 0.10f);
                }
                
                // now assign the values to the correct location in the array
                splat.Normalize();
                splatmapData[x, y, 0] = splat.x;
                splatmapData[x, y, 1] = splat.y;
                splatmapData[x, y, 2] = splat.z;
                splatmapData[x, y, 3] = splat.w;
            }
        }
        terrainData.SetAlphamaps(0, 0, splatmapData);
    }

    IEnumerator downloadImg(string url)
    {
        TerrainData tData = Terrain.activeTerrain.terrainData;
        Texture2D[] news = tData.alphamapTextures;

        WWW www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(news[4]);


        /*SplatPrototype[] terrainTexture = new SplatPrototype[1];
        terrainTexture[0] = new SplatPrototype();
        terrainTexture[0].texture = texture;
        tData.splatPrototypes = terrainTexture;*/

        /*Debug.Log("END!!");*/

        
    }

    // Use this for initialization
    void Start()
    {
        //StartCoroutine(downloadImg());
    }

    // Update is called once per frame
    void Update()
    {
        TerrainColor();
        BorderLow();
    }
}
