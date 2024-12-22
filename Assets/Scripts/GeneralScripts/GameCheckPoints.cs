using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCheckPoints : MonoBehaviour
{

    //private static int CheckPoint = 0;
    public int CheckPointNumber = 0; //Set in unity front end per object! Don't change unless you got a better way
    public int FinalCheckPoint; //Set in unity front end per object! Don't change unless you got a better way
    private float percentage = 0.1f;
    private int latestAvailableGamePosition = 0;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) { // Ensure the player has the "Player" tag 
            //TODO issue is here it's not selecting the specific player script I don't think!!
            playerProgressScript carProgress = other.GetComponent<playerProgressScript>();
            //TODO ISSUES HERE IT'S PICKING UP BOTH SCRIPS NOT JUST THE INDIVIDUAL ONE for that object! Need to fix,.s
            if(carProgress != null) {
                int NextCheckPoint = carProgress.checkPointStatusCheck() +1;
                if (CheckPointNumber != 0 && CheckPointNumber == NextCheckPoint) { 
                    carProgress.updatePlayerCheckpoint();  //Something is wrong here...
                    int CheckPoint = carProgress.checkPointStatusCheck();
                    NextCheckPoint += 1;
                    
                    //carProgress.checkPointStatus(1);
                    if (FinalCheckPoint == 1) { 
                        latestAvailableGamePosition++;
                        if (latestAvailableGamePosition == 1) {
                            carProgress.finishedPosition(1);
                        } else if (latestAvailableGamePosition == 2){
                            carProgress.finishedPosition(2);
                        } else if (latestAvailableGamePosition == 3) {
                            carProgress.finishedPosition(3);
                        } else {
                            carProgress.finishedPosition(latestAvailableGamePosition);
                        }
                        if (CheckPoint >= GlobalVariables.MaxCheckPointCount && latestAvailableGamePosition > GlobalVariables.MaxPlayerCount * percentage) {
                            //Here is what shall run when this reaches the end. I will set a timer on gamer manager at some point.
                            GameManagerScript.playerWinsGame();
                        }
                    }             
                    Debug.LogError("Player current position: " + CheckPoint + " next checkpoint is: " + NextCheckPoint);
                    Debug.Log("Check point hit.");
                }
            }
        }
    }
}
