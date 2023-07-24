using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloudOnce;

public class Highscore : MonoBehaviour
{

    public static int currentHigh = 0;
    public static Text highScore;

    void Awake()
    {
        highScore = GetComponent<Text>();
        highScore.text = PlayerPrefs.GetInt("Best", 0).ToString();
    }

    public static void SetHighScore()
    {
        currentHigh = PlayerPrefs.GetInt("Best");

        if (ScoreScript.scoreValue > currentHigh){

            PlayerPrefs.SetInt("Best", ScoreScript.scoreValue);

            Leaderboards.JumpyTurtleHighScore.SubmitScore(ScoreScript.scoreValue);

             highScore.text = PlayerPrefs.GetInt("Best").ToString();
        }
        else {
            highScore.text = PlayerPrefs.GetInt("Best").ToString();
        }
    }

}
