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
    public static int health = 10;
    public GameObject body;
    public GameObject corpse;
    public GameObject cam;
    public GameObject camHolder;

    [Header("Set Dynamically")]
    Rigidbody rigidBody;
    public GameObject projectilePrefab;
    private float lastFire;
    private GameObject lastTriggerGo = null;
    private Quaternion upDown= Quaternion.Euler(0,90,0);
    private Quaternion right = Quaternion.Euler(0, 27.098f, 0);
    private Quaternion left = Quaternion.Euler(0, -27.098f, 0);
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
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            body.transform.rotation = left;
        }else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            body.transform.rotation = right;
        }else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            body.transform.rotation = right;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            body.transform.rotation = left;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))               
        {
            body.transform.rotation = upDown;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            body.transform.rotation= right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            body.transform.rotation= left;
        }

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

        if (go.tag=="Enemy"||go.tag=="Dino"||go.tag=="enemyProj"||go.tag=="Fire")
        {
            
            if (health > 1)
            {
                if (go.tag == "Dino")
                {
                    health = health - 3;
                    Debug.Log(health);
                }
                else
                {
                    health--;
                }
                
            }
            else
            {
                corpse.SetActive(true);
                corpse.transform.position = transform.position;
                cam.transform.SetParent(camHolder.transform);
                health = 10;
                Destroy(gameObject);
                //Invoke("endGame", 5f);
                
            }
            if (go.tag == "enemyProj"||go.tag=="Fire")
            {
                Destroy(go);
            }
        }
    }
    public void resetDamager()
    {
        lastTriggerGo = null;
    }
    public void endGame()
    {
        SceneManager.LoadScene(2);
    }
}
