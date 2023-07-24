using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public GameManager manager;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Turtle")){
            manager.OnDeath();
        }
    }
}
