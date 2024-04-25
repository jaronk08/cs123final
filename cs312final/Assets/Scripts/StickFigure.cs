using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StickFigure : MonoBehaviour
{
    static public StickFigure S;

    [Header("Set in Inspector")]
    public float speed = 10f;
    public float projectileSpeed = 30f;
    public float fireDelay = 1;

    [Header("Set Dynamically")]
    Rigidbody rigidBody;
    public GameObject projectilePrefab;
    private float lastFire;

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
}
