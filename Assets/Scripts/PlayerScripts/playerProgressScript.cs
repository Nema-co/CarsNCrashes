using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerProgressScript : MonoBehaviour
{
    public int playerCheckPoint = 0; //Don't set this as static it'll create a bug with checkpoints.
    private int FinPosition;
    private int CheckPointNumber;
    private int PlayerPosNum = 1;


    public void updatePlayerCheckpoint() {
        playerCheckPoint++;
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
        Debug.Log("PlayerPosNum ++ check" + PlayerPosNum);
    }

    public void decreasePlayerPos() {
        PlayerPosNum--;
        Debug.Log("PlayerPosNum -- check" + PlayerPosNum);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Position") && other.gameObject != this.gameObject) {
            playerProgressScript otherPlayer = other.GetComponentInParent<playerProgressScript>(); //Don't remove collider from parent obj due to an issue
            if (otherPlayer != null) {
                if (otherPlayer.playerPosition() != 1) {
                    otherPlayer.decreasePlayerPos();
                    Debug.Log("Tag Position: " + playerPosition());
                } else {
                    Debug.Log("Player position is 1"); //Failing here. If statements need changing //TODO: 
                }
            } else {
                Debug.LogError("otherPlayer script is null");
            }
        } else if (!other.CompareTag("CheckPoint") && other.gameObject == this.gameObject) {
            increasePlayerPos();
            Debug.Log("Everything else " + playerPosition());
            //TODO: Need to update the UI script for both vehicles but will work on another day.
            //Doesn't cosider it's own collider and is a static placement so don't think it works.
        }
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
