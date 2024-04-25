using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_2 : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float fireDelayDec = 0.02f;
    public float fireSpeedInc = 2f;

    [Header("Set Dynamically")]
    public float newFireDelay;
    public float newFireSpeed;


    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            newFireDelay = StickFigure.S.fireDelay - fireDelayDec;
            newFireSpeed = StickFigure.S.projectileSpeed + fireSpeedInc;

            StickFigure.S.PowerUp2(newFireDelay,newFireSpeed);
        }
    }
}
