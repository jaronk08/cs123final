using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickFigure : MonoBehaviour
{
    static public StickFigure S;

    [Header("Set in Inspector")]
    public float speed = 30f;

    [Header("Set Dynamically")]
    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidBody.velocity = new Vector3(horizontal * speed, 0f, vertical * speed);
    }

}
