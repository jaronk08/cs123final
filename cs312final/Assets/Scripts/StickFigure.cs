using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StickFigure : MonoBehaviour
{
    static public StickFigure S;

    [Header("Set in Inspector")]
    public float speed = 10f;
    public float projectileSpeed = 30f;
    public float fireDelay = 1;
    public int health = 10;

    [Header("Set Dynamically")]
    Rigidbody rigidBody;
    public GameObject projectilePrefab;
    private float lastFire;
    private GameObject lastTriggerGo = null;

    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Debug.LogError("StickFigure.Awake() - Attempted to assign Hero.S");
        }
    }
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidBody.velocity = new Vector3(horizontal * speed, 0f, vertical * speed);

        //projectile shooting
        if(Time.time > lastFire + fireDelay)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Shoot(Vector3.forward);
                lastFire = Time.time;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Shoot(Vector3.back);
                lastFire = Time.time;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Shoot(Vector3.left);
                lastFire = Time.time;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Shoot(Vector3.right);
                lastFire = Time.time;
            }
        }
    }

    void Shoot(Vector3 direction)
    {
        Vector3 shootingPosition = transform.position;
        shootingPosition.y = shootingPosition.y + 3;

        //create projectile
        GameObject projectile = Instantiate(
            projectilePrefab, shootingPosition, transform.rotation) as GameObject;

        Rigidbody rigidBody =  projectile.GetComponent<Rigidbody>();

        rigidBody.velocity = direction * projectileSpeed;

    }

    //functions for setting powerups
    public void PowerUp1(float nSpeed)
    {
        speed = nSpeed;
    }

    public void PowerUp2(float nFdelay, float nFspeed)
    {
        projectileSpeed = nFspeed;
        fireDelay = nFdelay;
    }

    public void PowerUp3(int nHealth)
    {
        health=nHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Transform rootT = collision.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        //check for repeat triggers
        if (go == lastTriggerGo)
        {
            Invoke("resetDamager", 1f);
            return;
        }
        lastTriggerGo = go;

        if (go.tag=="Enemy")
        {
            Debug.Log("damaged");
            if (health > 1)
            {
                health--;
            }
            else
            {
                health = 10;
                SceneManager.LoadScene(2);
                
            }
        }
    }
    public void resetDamager()
    {
        lastTriggerGo = null;
    }
}
