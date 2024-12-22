using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProgressScript : MonoBehaviour
{
    public static int playerCheckPoint = 0;
    private int FinPosition;
    public static int CheckPointNumber;


    public void updatePlayerCheckpoint() {
        playerCheckPoint++;
        Debug.LogError("Player checkpoint: " + playerCheckPoint); 
    }

    public void finishedPosition(int positionNum)
    {
        FinPosition = positionNum;
    }

   /* public void checkPointStatus(int Status)
    {
        CheckPointNumber += 1;
        Debug.Log("Check point number: " + CheckPointNumber);
    }*/

    public int checkPointStatusCheck()
    {
        return playerCheckPoint;
    }
}
