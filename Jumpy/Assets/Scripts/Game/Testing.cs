using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Testing : MonoBehaviour
{

    public int test;
    public static TMP_Text score;

    void Start()
    {
        test = 1;
        score = GetComponent<TMP_Text>();
    }

    void Update()
    {
        test++;
        score.text = test.ToString();
    }
}
