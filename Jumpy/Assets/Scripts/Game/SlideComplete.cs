using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class SlideComplete : MonoBehaviour
{
    public static int count = 1;

    void OnSlideComplete()
    {

        // UNITY ADS (VIDEO)
        if (count % 3 == 0)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
            }
        }
        count += 1;
    }
}
