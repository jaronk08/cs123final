using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_1 : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float speedMult = 3f;

    [Header("Set Dynamically")]
    public float newSpeed;


    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            newSpeed = StickFigure.S.speed * speedMult;
            StickFigure.S.PowerUp1(newSpeed);
        }
    }
}
