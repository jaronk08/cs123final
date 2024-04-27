using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Text scoreUI;
    public int scoreTotal = 0;
    public void AddScore(int s)
    {
        //Add score total, update UI.
        scoreTotal += s;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreUI.text = "Score: " + scoreTotal.ToString();
    }
}
