using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCheckPoints : MonoBehaviour
{

    //private static int CheckPoint = 0;
    public int CheckPointNumber = 0; //Set in unity front end per object! Don't change unless you got a better way
    private int MissedCheckPoint;
    public int FinalCheckPoint = 0;
    private float percentage = 0.1f;
    private int latestAvailableGamePosition = 0;

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Contains("Player")) { // Ensure the player has the "Player" tag 
            playerProgressScript carProgress = other.GetComponent<playerProgressScript>();
            if(carProgress != null) {
                carProgress.PlayerProgress();
                carProgress.checkPointStatus(1);
                if (FinalCheckPoint == 1) {
                 latestAvailableGamePosition++;

                    if (latestAvailableGamePosition == 1) {
                        carProgress.finishedPosition(1);

                    } else if (latestAvailableGamePosition == 2) {
                        carProgress.finishedPosition(2);

                    } else if (latestAvailableGamePosition == 3) {
                        carProgress.finishedPosition(3);

                    } else {
                        carProgress.finishedPosition(latestAvailableGamePosition);
                    }
                int CheckPoint = carProgress.checkPointStatusCheck();
                if (CheckPoint >= GlobalVariables.MaxCheckPointCount && latestAvailableGamePosition > GlobalVariables.MaxPlayerCount * percentage) {
                        //Here is what shall run when this reaches the end. I will set a timer on gamer manager at some point.
                        GameManagerScript.playerWinsGame();
                    }
                }
            }
        }
    }
}
