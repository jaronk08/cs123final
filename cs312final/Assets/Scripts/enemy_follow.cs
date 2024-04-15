using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_follow : MonoBehaviour
{

    [Header("Set in Inspector")]
    public string targetTag = "Player"; //player tag
    public float followSpeed = 5f;
    public float pushForce = 10f;

    private Transform targetTransform;
    private GameObject targetObject;
    private float lockedY = 1.4f;

    private void Awake()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        if (targetObject != null)
        {
            targetTransform = targetObject.transform;
        }
    }
    //find tag at start
    void Start()
    {
       
    }

    
    void Update()
    {
        if (targetTransform != null)
        {
            //find direction
            Vector3 direction = targetTransform.position - transform.position;

            //get distance
            float distanceToTarget = direction.magnitude;           
            direction.Normalize();

            //get movement
            float movementAmount = followSpeed * Time.deltaTime;
          
            // Move towards the player
            Vector3 tempPos=transform.position += direction * movementAmount;
            tempPos.y = lockedY;
            transform.position = tempPos;
        }
    }
   
}
