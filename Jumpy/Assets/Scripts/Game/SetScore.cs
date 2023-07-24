using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{

    public static Text FinalScore;

    void Awake()
    {
        FinalScore = GetComponent<Text>();
    }

    public static void Score()
    {
        FinalScore.text = "" + ScoreScript.scoreValue;
    }
}
