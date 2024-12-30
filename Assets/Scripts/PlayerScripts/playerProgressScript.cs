using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class playerProgressScript : MonoBehaviour
{
    public int playerCheckPoint = 0; //Don't set this as static it'll create a bug with checkpoints.
    private int FinPosition;
    private int CheckPointNumber;
    private int PlayerPosNum = 1;
    private int[] GamePositions = { 1, 2, 3, 4, 5, 6, 7, 8 };
    private float DistanceCheck = 8f;


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
        Debug.Log("PlayerPosNum ++ check" + PlayerPosNum.ToString());
    }

    public void decreasePlayerPos() {
        PlayerPosNum--;
        Debug.Log("PlayerPosNum -- check" + PlayerPosNum);
    }

    private void Update() {
        checkOvertake();
    }

    private void checkOvertake() { //Needs to try change this to not detect current car so we don't hardcode values. Need to at a quatorian.Eular for rotate of the raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceCheck)) {
            //&& !this.GetComponentInChildren<Collider>()) { //Need to stop it detecting its own position collider
            if (hit.collider.CompareTag("Position") && !hit.collider.CompareTag("CheckPoint")) { 
                playerProgressScript otherCar = hit.collider.GetComponentInParent<playerProgressScript>();
                if (otherCar != null && otherCar.playerPosition() > playerPosition()) {
                    // Overtake: Update both cars' positions
                    //(otherCar);
                    otherCar.decreasePlayerPos(); //Decrese from 2 > 1 etc
                    if (this.playerPosition() < 8) {
                        this.increasePlayerPos();
                    }
                    Debug.Log("Got here?!");
                } else {

                    Debug.Log("otherCar script is null or other car player position is not greater than current car");
                }
            } else {
                Debug.Log("No tag Position or a checkpoint has been hit.");

            }
        } 
       Vector3 test = transform.forward * DistanceCheck;
       Debug.DrawRay(transform.position + Vector3.up * 0.8f, transform.forward * DistanceCheck, Color.red); //Used for debugging TEST
       //Debug.DrawLine(transform.position, transform.position + test, Color.red);

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
