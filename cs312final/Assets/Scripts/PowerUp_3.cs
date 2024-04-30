using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_3 : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int healAmount = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (StickFigure.health <= 8)
        {
            StickFigure.health = StickFigure.health+healAmount;
            Debug.Log(StickFigure.health);
        }else if(StickFigure.health == 9)
        {
            StickFigure.health=StickFigure.health+1;
            Debug.Log(StickFigure.health);
        }
    }
}
