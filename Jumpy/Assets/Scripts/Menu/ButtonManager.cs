using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class ButtonManager : MonoBehaviour
{
    public bool isPressed = false;

    public GameObject playButton;
    public GameObject rateButton;

    public Animator animator;

    void Start()
    {
        Cloud.Initialize(false, true);
    }

    public void Leaderboard()
    {
        FindObjectOfType<AudioManager>().ButtonPressed("ButtonClick");
    }

    public void Rate()
    {
        FindObjectOfType<AudioManager>().ButtonPressed("ButtonClick");

        #if UNITY_ANDROID
            Application.OpenURL("market://details?id=com.unKnown.JumpyTurtle");
        #elif UNITY_IPHONE
            Application.OpenURL("itms-apps:itunes.apple.com/app/Jumpy-Turtle-Game/id1507229830");
        #endif
    }

    public void Play()
    {
        if (!isPressed){
            FindObjectOfType<AudioManager>().ButtonPressed("ButtonClick");

            isPressed = true;

            animator.SetTrigger("PlayButtonPressed");
        }
    }
}
