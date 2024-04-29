using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMan : MonoBehaviour
{
   public static ScoreMan instance;

    public Text ScoreText;
    public static int score = 0;
    public Text HealthText;
    public static int health=StickFigure.S.health;

    private void Update()
    {
        ScoreText.text = "Score: " + score;
        HealthText.text = "Health: " + health;
    }
}
