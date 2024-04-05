using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickFigure : MonoBehaviour
{
    static public StickFigure S;

    [Header("Set in Inspector")]
    public float speed = 30f;

    //[Header("Set Dynamically")]
    //private float healthLevel = 1;

    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x = xAxis * speed * Time.deltaTime;
        pos.y = yAxis * speed * Time.deltaTime;

        transform.position = pos;
    }
}
