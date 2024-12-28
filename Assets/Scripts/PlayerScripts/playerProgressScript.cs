using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProgressScript : MonoBehaviour
{
    public int playerCheckPoint = 0; //Don't set this as static it'll create a bug with checkpoints.
    private int FinPosition;
    public int CheckPointNumber;
    public int PlayerPosNum = 1;
    


    public void updatePlayerCheckpoint() {
        playerCheckPoint++;
        Debug.LogError("Player checkpoint: " + playerCheckPoint); 
    }

    public void finishedPosition(int positionNum){
        FinPosition = positionNum;
    }

   /* public void checkPointStatus(int Status)
    {
        CheckPointNumber += 1;
        Debug.Log("Check point number: " + CheckPointNumber);
    }*/

    public void increasePlayerPos() {
        PlayerPosNum++;
    }

    public void decreasePlayerPos() {
        PlayerPosNum--;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Position")) {
           playerProgressScript otherPlayer = other.GetComponent<playerProgressScript>();
           otherPlayer.decreasePlayerPos();
        }
        increasePlayerPos();
        Debug.Log("Player position: " + playerPosition());
        //TODO: Need to update the UI script for both vehicles but will work on another day.
        //Doesn't consider ignoring it's own asset.
    }

    public int checkPointStatusCheck() {
        return playerCheckPoint;
    }

    public int playerPosition() {
        if (PlayerPosNum == 0) { //TODO: Need to check each players position based on starting point.
            throw new System.Exception("Player position appears 0, should be 1 by default.");
        }
       return PlayerPosNum;

    }
}
