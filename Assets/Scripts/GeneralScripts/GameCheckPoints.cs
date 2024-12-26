using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCheckPoints : MonoBehaviour
{

    //private static int CheckPoint = 0;
    public int CheckPointNumber = 0; //Set in unity front end per object! Don't change unless you got a better way
    public int FinalCheckPoint; //Set in unity front end per object! Don't change unless you got a better way
    private float percentage = 0.1f;
    private int CurrentPosition = 0;

    public void OnTriggerEnter(Collider other) {

        //TODO: Needs rewrite had to move player Progress script to overall parent object now it doesn't work. Issue appears on PlayerUIScript but now introduced here
        if (other.CompareTag("Player")) { // Ensure the player has the "Player" tag
            playerProgressScript carProgress = other.GetComponentInParent<playerProgressScript>();
            if(carProgress != null) {
                int NextCheckPoint = carProgress.checkPointStatusCheck() +1;
                if (CheckPointNumber != 0 && CheckPointNumber == NextCheckPoint) { 
                    carProgress.updatePlayerCheckpoint();  //Something is wrong here...
                    int CheckPoint = carProgress.checkPointStatusCheck();
                    NextCheckPoint += 1;
                    
                    //carProgress.checkPointStatus(1);
                    if (FinalCheckPoint == 1) {
                        CurrentPosition++;
                        if (CurrentPosition == 1) {
                            carProgress.finishedPosition(1);
                        } else if (CurrentPosition == 2){
                            carProgress.finishedPosition(2);
                        } else if (CurrentPosition == 3) {
                            carProgress.finishedPosition(3);
                        } else {
                            carProgress.finishedPosition(CurrentPosition);
                        }
                        if (CheckPoint >= GlobalVariables.MaxCheckPointCount && CurrentPosition > GlobalVariables.MaxPlayerCount * percentage) {
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
