using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVelocity : MonoBehaviour
{
    public float moveSpeed = -10.0f;
    public bool started = false;

    public LevelGenerator levelGen;

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(1f, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
                                    // -18
        if (transform.position.x <= -10 && !started){
            levelGen.StartCo();
            started = true;
        }

        if (transform.position.x < -70){
            Destroy(this.gameObject);
        }
    }
}
