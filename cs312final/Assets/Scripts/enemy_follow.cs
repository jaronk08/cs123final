using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_follow : MonoBehaviour
{
    public Main S;
    [Header("Set in Inspector")]
    public string targetTag = "Player"; //player tag
    public float followSpeed = 5f;
    public float pushForce = 10f;
    public float pushDuration = 1f;
    

    private Transform targetTransform;
    private GameObject targetObject;
    private float lockedY = 1.6f;
    private bool hasPassed = false;
    private void Awake()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        if (targetObject != null)
        {
            targetTransform = targetObject.transform;
        }
        S = FindObjectOfType<Main>();
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
        if (hasPassed && S.scoreShow() > 250)
        {
            hasPassed = true;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other=collision.gameObject;
        if (other.tag == "Player")
        {
            
            StartCoroutine(ApplyPushForce(collision.rigidbody, collision.contacts[0].point));
        }
    }

    IEnumerator ApplyPushForce(Rigidbody rb, Vector3 contactPoint)
    {
        // Calculate the direction from the collided object to this GameObject
        Vector3 pushDirection = contactPoint - transform.position;
        pushDirection = pushDirection.normalized;

        float elapsedTime = 0f;

        // Apply force over time
        while (elapsedTime < pushDuration)
        {
            // Calculate the force to apply at this frame
            float forceMagnitude = Mathf.Lerp(0, pushForce, elapsedTime / pushDuration);
            Vector3 force = pushDirection * forceMagnitude;

            // Apply force to the collided object
            if(targetObject != null)
            {
                rb.AddForce(force, ForceMode.Impulse);
            }
            

            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
