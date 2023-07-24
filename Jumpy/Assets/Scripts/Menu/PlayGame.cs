using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public bool isPressed = false;

    public Animator animator;

    public void Play()
    {

        FindObjectOfType<AudioManager>().ButtonPressed("ButtonClick");

        if (!isPressed){
            isPressed = true;
            animator.SetTrigger("PlayButtonPressed");
        }
    }
}
