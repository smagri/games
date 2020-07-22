using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerControls is the class name, filename, and the name of our Component
public class PlayerControls : MonoBehaviour
{
    // public variables are available outside this class, private are only available to this class

    // keys to move the paddles up and down
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 2.25f; // Maximum position, in the y direction, the paddle can go to.
                                 // I keeps it from moving off the edges of the screen.
    private Rigidbody2D  rb2d; // object of type Rigidbody allows us to acess the component Rigidbody2D                          


  
    // Start is called before the first frame update
    void Start()
    {
        // The object rb2d is assigned to the 2D ridgidbody component
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    
    void Update()
    {
        // define variable to access the velocity of the Rigidbody2d
        var vel = rb2d.velocity;
        if (Input.GetKey(moveUp)){ // move paddle up if moveUp key is pressed
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown)){ // move paddle down if moveDown key is pressed
            vel.y = -speed;
        }
        else{
            vel.y = 0; // do not move paddle if niether the move up or down key is pressed
        }
        rb2d.velocity = vel; // set 2D ridgidbody component velocity accordingly

        // If the paddle  y direction asked for is outside the maximum allowd, rain it in
        var pos = transform.position;
        if (pos.y > boundY){
            pos.y = boundY;
        }
        else if (pos.y < -boundY){
            pos.y = -boundY;
        }
        transform.position = pos;

        
    }
}
