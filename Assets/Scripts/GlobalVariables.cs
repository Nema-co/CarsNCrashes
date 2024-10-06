using System;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public int FinalCheckPointReached = 0;
    public void PlayerFinished(int CheckPoint)
    {
        FinalCheckPointReached = CheckPoint;
        Debug.Log("Game finished " + FinalCheckPointReached);
    }
}
