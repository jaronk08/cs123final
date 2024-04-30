using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject objectToLaunch; // Prefab of the object to be launched
    private GameObject target;
    private Transform launchTarget; // Target towards which objects will be launched
    private Quaternion initialRot= Quaternion.Euler(90,0,0);
    public int numberOfObjects = 5; // Number of objects to launch
    public float launchSpeed = 10f; // Speed at which objects will be launched
    public float launchSpread = 5f; // Spread in the launch area
    public float maxRotationAngle = 10f; // Maximum rotation angle for randomization

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        launchTarget = target.GetComponent<Transform>();
    }
    void Start()
    {
        Launch();
    }

    void Launch()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Calculate a random position within the launch area
            Vector3 launchPosition = transform.position;

            // Calculate direction towards the target
            Vector3 launchDirection = (launchTarget.position - launchPosition).normalized;

            // Apply random rotation to the launch direction
            launchDirection = Quaternion.Euler(Random.Range(-maxRotationAngle, maxRotationAngle), Random.Range(-maxRotationAngle, maxRotationAngle), Random.Range(-maxRotationAngle, maxRotationAngle)) * launchDirection;

            // Instantiate the object at the calculated position
            GameObject newObject = Instantiate(objectToLaunch, launchPosition, initialRot);

            // Get the Rigidbody component of the launched object
            Rigidbody rb = newObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Apply force to launch the object towards the target
                rb.velocity = launchDirection * launchSpeed;
            }
            else
            {
                Debug.LogWarning("Rigidbody component not found on the object to launch.");
            }
        }
        Invoke("Launch", 5f);
    }
}
