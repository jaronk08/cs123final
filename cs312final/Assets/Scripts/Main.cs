using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public EnemySpawning S;

    public Text scoreUI;
    public int scoreTotal = 0;

    public bool diffInc1 = false; //increases spawn rate
    public bool diffInc2 = false; //spawns boss1
    public bool diffInc3 = false; //increases spawn rate
    public bool diffInc4 = false; //spawns boss2

    private void Update()
    {
        if (scoreTotal > 30 && diffInc1 == false)
        {
            S.SetSpawnRate(0.4f);
            diffInc1 = true;
            Debug.Log("Diff Inc. 1");
        }
        if (scoreTotal > 75 && diffInc2 == false)
        {
            S.SpawnBoss1();
            diffInc2 = true;
            Debug.Log("Diff Inc. 2");
        }
        if (scoreTotal > 125 && diffInc3 == false)
        {
            S.SetSpawnRate(1f);
            diffInc3 = true;
            Debug.Log("Diff Inc. 3");
        }
        if (scoreTotal > 200 && diffInc4 == false)
        {
            //*************************************
            diffInc4 = true;
            Debug.Log("Diff Inc. 4");
        }
    }

    private void Start()
    {
        S = FindObjectOfType<EnemySpawning>();
    }

    public void AddScore(int s)
    {
        //Add score total, update UI.
        scoreTotal += s;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreUI != null)
        {
            scoreUI.text = "Score: " + scoreTotal.ToString();
        }
       
    }
}
