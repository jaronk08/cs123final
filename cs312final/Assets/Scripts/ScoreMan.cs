using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMan : MonoBehaviour
{
   public static ScoreMan instance;

    public GameObject hero=GameObject.Find("StickFigure");
    public Text ScoreText;
    public static int score = 0;

    private void Update()
    {
        if(hero != null)
        {
            ScoreText.text = "Score: " + score;
        }
        else
        {
            Debug.Log("not found");
        }
        
    }
}
