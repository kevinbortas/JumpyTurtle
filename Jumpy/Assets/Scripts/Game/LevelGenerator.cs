using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platform;

    public bool firstPlatform;

    public float levelHeight;
    public float spawn;

    void Start()
    {
        firstPlatform = true;
    }

    public void StartCo()
    {
        StartCoroutine(platformInit());
    }

    private void spawnPlatform()
    {
        GameObject p = Instantiate(platform) as GameObject;

        if (!firstPlatform)
        {
            spawn = Random.Range(-5.5f, levelHeight);
            p.transform.position = new Vector2(17.0f, spawn);
        }
        else
        {
            p.transform.position = new Vector2(17.0f, -5.5f);
            firstPlatform = false;
        }
    }

    public IEnumerator platformInit()
    {
        while(true){
            yield return new WaitForSeconds(Random.Range(0.50f, 1.10f));
            spawnPlatform();
        }
    }
}
