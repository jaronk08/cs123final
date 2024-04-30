using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maintainTarget : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 edit=Vector3.zero;
    private GameObject target;
    private Transform targetTransform;
    private Quaternion targetRotation;

    private void Awake()
    {
        
        target = GameObject.FindGameObjectWithTag("Player");
        targetTransform = target.transform;
        Invoke("kill", 3f);
    }

    void Start()
    {
        transform.LookAt(targetTransform);
        targetRotation = Quaternion.Euler(90,transform.rotation.y,transform.rotation.z);
        transform.rotation = targetRotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        edit.x = transform.position.x;
        edit.z = transform.position.z;
        edit.y = 1.6f;
        if (transform.position.y != 1.6f)
        {
            transform.position = edit;
        }
    }

    void kill()
    {
        Destroy(gameObject);
    }
}
