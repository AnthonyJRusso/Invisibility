using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Allows speed to be set in scene
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        //4-directional movement for player
        float x_value = (Input.GetAxisRaw("Horizontal") * moveSpeed);
        float y_value = (Input.GetAxisRaw("Vertical") * moveSpeed);

        transform.position += new Vector3(x_value * Time.deltaTime, y_value * Time.deltaTime, 0f);
    }
}
