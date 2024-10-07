using System;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public int FinalCheckPointReached = 0;
    public void PlayerFinished(int CheckPoint)
    {
        FinalCheckPointReached = 1;

        //Used for when editor is active can switch this off whenever you need by commenting it out
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Game finished!!!!");
    }
}
