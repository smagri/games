using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{

void OnTriggerEnter2D (Collider2D hitInfo) {
    if (hitInfo.name == "Ball")
        {
            // did the ball hit the LeftWall or the RightWall
            string wallName = transform.name;

            // player1/2 score++
            GameManager.Score(wallName); // this method in GameManager.cs

            // call RestartGame() method in BallControl script, moving the ball to middle of screen
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
