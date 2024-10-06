using System;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public int FinalCheckPointReached = 0;
    public void PlayerFinished(int CheckPoint)
    {
        FinalCheckPointReached = CheckPoint;
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Debug.Log("Game finished " + FinalCheckPointReached);
    }
}
