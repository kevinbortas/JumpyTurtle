using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnFadeComplete : MonoBehaviour
{

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("Menu");
    }
}
