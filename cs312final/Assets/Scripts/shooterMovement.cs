using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class shooterMovement : MonoBehaviour
{
    public Main S;
    [Header("Set in Inspector")]
    public string targetTag = "Player"; //player tag
    public float followSpeed = 5f;
    public float pushForce = 10f;
    public float pushDuration = 1f;
    public float stoppingDistance = 1f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 30f;
    public float fireDelay = 1;

    private Transform targetTransform;
    private GameObject targetObject;
    private float lockedY = -1.21f;
    private float lastFire;
    private bool hasPassed = false;
    private void Awake()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        if (targetObject != null)
        {
            targetTransform = targetObject.transform;
        }
        if (targetObject!=null)
        {
            Invoke("Shoot", 5f);
        }
        S = FindObjectOfType<Main>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            Vector3 direction = targetTransform.position - transform.position;

            if (direction.magnitude > stoppingDistance)
            {
                direction.Normalize();

                //get movement
                float movementAmount = followSpeed * Time.deltaTime;

                // Move towards the player
                Vector3 tempPos = transform.position += direction * movementAmount;
                tempPos.y = lockedY;
                transform.position = tempPos;
            }
        }

        if (hasPassed && S.scoreShow() > 250)
        {
            hasPassed = true;
            Destroy(gameObject);
        }

    }

    void Shoot()
    {
        if (targetObject != null)
        {
            Vector3 direction = targetTransform.position - transform.position;
            Vector3 shootingPosition = transform.position;
            shootingPosition.y = shootingPosition.y - 39f;

            GameObject projectile = Instantiate(projectilePrefab, shootingPosition, transform.rotation) as GameObject;
            Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();

            rigidBody.velocity = direction * projectileSpeed;
            if (gameObject != null)
            {
                Invoke("Shoot", 3f);
            }
        }
       
    }
}
