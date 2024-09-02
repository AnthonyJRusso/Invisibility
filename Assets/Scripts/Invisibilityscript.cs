using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibilityscript : MonoBehaviour
{
    //Drag in object with sprite renderer you want to turn invisible
    public SpriteRenderer spr;

    Collider2D colldr;

    //Set time of invisibility
    public float invisTime = 2f;

    private bool timerOn;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        colldr = GetComponent<Collider2D>();
    }

    void Update()
    {   
        //Spacebar to go invisible
        if(Input.GetKeyDown(KeyCode.Space)){

            //Player sprite reduces opacity
            spr.color = new Color(1, 1, 1, 0.01f);
            //Checks player collider as trigger
            colldr.isTrigger = true;
            //Starts time limit
            timerOn = true;
        }

        if(timerOn == true){
            //Makes the time go towards zero
            invisTime -= Time.deltaTime;

            if(invisTime <= 0){
                //Player sprite regains its opacity
                spr.color = new Color(1, 1, 1, 1f);
                //Player collider is no longer a trigger
                colldr.isTrigger = false;
                //Ends time limit
                timerOn = false;
                //Resets time 
                invisTime = 2f;
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //Checks if object has Sidescript added to it. Add the Sidescript to anything the player should never be able to pass through even when invisible
        Sidescript side = collision.gameObject.GetComponent<Sidescript>();

        if(side){
            
            //Player sprite regains its opacity
            spr.color = new Color(1, 1, 1, 1f);
            //Player collider is no longer a trigger
            colldr.isTrigger = false;
            //Ends time limit
            timerOn = false;
            //Resets time 
            invisTime = 2f;
        }
    }
}
