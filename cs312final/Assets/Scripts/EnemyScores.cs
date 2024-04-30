using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyScores : MonoBehaviour
{
    public Main main;

    [Header("Set in Inspector")]
    public int enemyScore = 10;

    void Start()
    {
        main = FindObjectOfType<Main>();
    }

    private void OnDestroy()
    {
        if (main != null)
        {
           // main.AddScore(enemyScore);
        }
    }
    

}
