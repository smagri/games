// packages of pre-written code we want our program to use
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classname must match filename
public class BallControl : MonoBehaviour
{
    public Rigidbody2D rb2d; // assign object to component

    void GoBall(){
        // move ball in left or right direction???
        float rand = Random.Range(0, 2); // return random number between 0 and 2
        if (rand < 1){
            // fource = mass * acceleration
            rb2d.AddForce(new Vector2(20, -15)); // move x,-y
        }
        else{
            rb2d.AddForce(new Vector2(-20, -15)); // move -x,-y
        }
    }

    void ResetBall(){
        // called when a player wins a game
        rb2d.velocity = Vector2.zero; // stop ball moving
        transform.position = Vector2.zero; // position it at centre of screen
    }

    void RestartGame(){
        // called when the restart button is pressed
        ResetBall(); 
        Invoke("GoBall", 1); // wait one second before ball starts moving again
    }

    void OnCollisionEnter2D(Collision2D coll){
        // Waits until we collide with a paddle, then adjusts the velocity
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = rb2d.velocity.x; // leave velocity in x direction as is

            // adjust the velocity in the y direction, fn of (ball velocity + paddle velocity)
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2); // wait 2 seconds before starts moving, so players can get ready
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
