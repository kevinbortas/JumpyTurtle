using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue;
    public static TMP_Text score;

    void Start()
    {
        scoreValue = 0;
        score = GetComponent<TMP_Text>();
    }

    void Update()
    {
        score.text = scoreValue.ToString();
    }
}
