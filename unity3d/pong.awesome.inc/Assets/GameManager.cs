using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class, object and file name, GameManager
public class GameManager : MonoBehaviour
{
    // keep track of player scores
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout; // GUI object for buttons, graphics...etc
    GameObject theBall; // variable to our ball object reference

    // This called by the SideWalls script that detects when the ball hits the side walls
    public static void Score (string wallID) {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
        }else{
            PlayerScore2++;
        }
    }

    void OnGUI(){
        // GUI skin, displays the score and reset button
        GUI.skin = layout;

        // create and place labels called 'PlayerScore1' and 'PlayerScore2'
        GUI.Label(new Rect(Screen.width /2 - 150 -12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width /2 + 150 +12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        // Display which player wins the game, ie when a player accumilates a score of 10.
        // Then calls ResetBall() function restarting the game from scratch.
        if (PlayerScore1 == 10){
            GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            
            // classname.memberfn = BallControl class object.SenMessage("trigger method in this class")
		    theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);   
        }
        else if (PlayerScore2 == 10){
            GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
