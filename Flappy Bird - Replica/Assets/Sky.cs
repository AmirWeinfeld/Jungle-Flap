using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sky : MonoBehaviour
{
    private int currentSkyIndex;
    public Color[] seaColors;
    public SpriteRenderer SeaRenderer, currRenderer;
    public Sprite[] skySprites;

    private float speed = 3;

    private bool isOnlySky = false;

    void Awake ()
    {
        currentSkyIndex = 0;
        GameObject[] tempSky = GameObject.FindGameObjectsWithTag("sky");

        if (tempSky.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            isOnlySky = true;
        }
    }

    void OnLevelWasLoaded(int level)
    {
        if (isOnlySky)
        {
            GameObject sky = GameObject.FindGameObjectWithTag("sky");
            Sky skyScript = sky.GetComponent<Sky>();

            int skyIndex = currentSkyIndex + 1;
            if (skyIndex >= skySprites.Length)
            {
                skyIndex = 0;
            }
            SetSkyIndex(skyIndex);
            currRenderer.sprite = skySprites[skyIndex];

            SeaRenderer.color = seaColors[currentSkyIndex];
            
            GameObject.FindGameObjectsWithTag("menu")[0].GetComponent<Menu>().SetSceneSpeed(speed);
        }
    }

    public void SetSpeed(float newSpeed) // setting new speed
    {
        speed = newSpeed;
    }

    public void SetSkyIndex(int i)
    {
        currentSkyIndex = i;
    }
    
    public int GetSkyIndex()
    {
        return currentSkyIndex;
    }
}
