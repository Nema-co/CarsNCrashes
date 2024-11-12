using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProgressScript : MonoBehaviour
{
    private int playerCheckPointCount = 0;
    private int FinPosition;
    public static int CheckPointNumber;


    public void PlayerProgress()
    {
        playerCheckPointCount++;
    }

    public void finishedPosition(int positionNum)
    {
        FinPosition = positionNum;
    }

    public void checkPointStatus(int Status)
    {
        CheckPointNumber = CheckPointNumber + 1;
        Debug.Log("Check point number: " + CheckPointNumber);
    }

    public int checkPointStatusCheck()
    {
        return CheckPointNumber;
    }
}
