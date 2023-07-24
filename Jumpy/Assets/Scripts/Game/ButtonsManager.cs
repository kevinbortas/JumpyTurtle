using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{

    public bool isPressed;

    public bool isPaused;

    public static bool isDead;

    public Animator animator;

    void Start()
    {
        FindObjectOfType<AudioManager>().ButtonPressed("Loading");

        isPressed = false;
        isDead = false;
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Return()
    {
        FindObjectOfType<AudioManager>().ButtonPressed("ButtonClick");

        if (!isPressed){
            isPressed = true;
            animator.SetTrigger("PlayButtonPressed");
        }
    }

    public void Leaderboard()
    {
        FindObjectOfType<AudioManager>().ButtonPressed("ButtonClick");
        Debug.Log("Loading leaderboard....");
    }

    public void Pause()
    {
        FindObjectOfType<AudioManager>().ButtonPressed("ButtonClick");

        if (!isDead)
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
}
