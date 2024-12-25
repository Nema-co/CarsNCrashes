using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProgressScript : MonoBehaviour
{
    public int playerCheckPoint = 0; //Don't set this as static it'll create a bug with checkpoints.
    private int FinPosition;
    public int CheckPointNumber;
    private int PlayerPosNum = 1;
    


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
        if(other.CompareTag("Player")) {
           playerProgressScript otherPlayer = other.GetComponent<playerProgressScript>();
           otherPlayer.increasePlayerPos();
        }
        decreasePlayerPos();
        //TODO: Need to update the UI script for both vehicles but will work on another day.
    }

    public int checkPointStatusCheck() {
        return playerCheckPoint;
    }

    public int playerPosition() {
        return PlayerPosNum;
    }
}
