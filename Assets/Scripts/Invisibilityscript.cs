using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibilityscript : MonoBehaviour
{
    //Drag in object with sprite renderer you want to turn invisible
    public SpriteRenderer spr;

    //Set time of invisibility
    public float invisTime = 2f;

    //Array of walls the player will be able to pass through during invisibility
    public GameObject[] invisWalls;

    //Starts timer for length of invisibility
    private bool timerOn;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {   
        //Spacebar to go invisible
        if(Input.GetKeyDown(KeyCode.Space)){
            //Turns the colliders of all walls placed in array to triggers, allowing player to pass through them
            foreach(GameObject i in invisWalls){
                Collider2D colldr = i.GetComponent<Collider2D>();
                colldr.isTrigger = true;
            }
            //Player sprite reduces opacity
            spr.color = new Color(1, 1, 1, 0.01f);
            //Starts time limit
            timerOn = true;
        }

        if(timerOn == true){
            //Makes the time go towards zero
            invisTime -= Time.deltaTime;

            if(invisTime <= 0){
                //Player sprite regains its opacity
                spr.color = new Color(1, 1, 1, 1f);
                //Ends time limit
                timerOn = false;
                //Resets time 
                invisTime = 2f;
                //Turns the colliders of walls in the array back to normal
                foreach(GameObject i in invisWalls){
                Collider2D colldr = i.GetComponent<Collider2D>();
                colldr.isTrigger = false;
                }
            }
        } 
    }
}
