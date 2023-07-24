using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeComplete : MonoBehaviour
{

    public InitializeAdmob adManager;

    void Awake()
    {
        FindObjectOfType<AudioManager>().ButtonPressed("Loading");
    }

    public void OnFadeComplete()
    {
        adManager.DestroyBanner();
        SceneManager.LoadScene("Game");
    }
}
