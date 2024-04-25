using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMan : MonoBehaviour
{
   public static ScoreMan instance;

    public Text ScoreText;
    public static int score = 0;

    private void Update()
    {
        ScoreText.text = "Score: " + score;
    }
}
