using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteLoop : MonoBehaviour
{

    public Transform platform1;
    public Transform platform2;

    private Vector3 platformStart;
    private Vector3 platformSpawn;

    public bool teleported = false;

    void Start()
    {
        Time.timeScale = 1f;
        platformStart = platform1.position;
        platformSpawn = platform2.position;
    }

    void FixedUpdate()
    {
        if ((platform2.position.x <= platformStart.x) && !teleported)
        {
            platform1.position = platformSpawn;

            teleported = true;
        }

        if ((platform1.position.x <= platformStart.x) && teleported)
        {
            platform2.position = platformSpawn;

            teleported = false;
        }
    }
}
