using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class explode : MonoBehaviour
{
    public float repulsion = 9.8f;

    private void OnTriggerStay(Collider other)
    {
        RepelObjects(other);

    }

    private void Awake()
    {
        Invoke("endGame", 5f);
    }


    void Update()
    {
        
    }
    private void RepelObjects(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            Vector3 repelDirection = (other.transform.position - transform.position).normalized;
            rb.AddForce(repelDirection * repulsion, ForceMode.Acceleration);
            
        }

    }
    public void endGame()
    {
        SceneManager.LoadScene(2);
    }
}
