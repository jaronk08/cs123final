using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHoming : MonoBehaviour
{
    private Transform target;
    private float speed;

    public void SetTarget(Transform target, float speed)
    {
        this.target = target;
        this.speed = speed;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 targetDirection = (target.position - transform.position).normalized;
        transform.position += targetDirection * speed * Time.deltaTime;
        transform.LookAt(target);
    }
}
