using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCheckPoints : MonoBehaviour
{

    private static int CheckPoint = 0;
    public int CheckPointNumber = 0; //Set in unity front end per object! Don't change
    private int MissedCheckPoint;
    private int MaxCheckPoints = 8;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player")) // Ensure the player has the "Player" tag
        {
           if (CheckPointNumber == 1 && CheckPoint == 0)
            {
                CheckPoint = 1; // Increment the counter
                Debug.Log("Checkpoint reached! Total checkpoints: " + CheckPoint);
            }
            else if (CheckPointNumber == 2 && CheckPoint == 1)
            {
                CheckPoint = 2; // Increment the counter
                Debug.Log("Checkpoint reached! Total checkpoints: " + CheckPoint);
            }
            else if (CheckPointNumber == 3 && CheckPoint == 2)
            {
                CheckPoint = 3; // Increment the counter
                Debug.Log("Checkpoint reached! Total checkpoints: " + CheckPoint);
            }
            else if (CheckPointNumber == 4 && CheckPoint == 3)
            {
                CheckPoint = 4; // Increment the counter
                Debug.Log("Checkpoint reached! Total checkpoints: " + CheckPoint);
            }
            else if (CheckPointNumber == 5 && CheckPoint == 4)
            {
                CheckPoint = 5; // Increment the counter
                Debug.Log("Checkpoint reached! Total checkpoints: " + CheckPoint);
            }
            else if (CheckPointNumber == 6 && CheckPoint == 5)
            {
                CheckPoint = 6; // Increment the counter
                Debug.Log("Checkpoint reached! Total checkpoints: " + CheckPoint);
            }
            else if (CheckPointNumber == 7 && CheckPoint == 6)
            {
                CheckPoint = 7; // Increment the counter
                Debug.Log("Checkpoint reached! Total checkpoints: " + CheckPoint);
            }
            else if (CheckPointNumber == 8 && CheckPoint == 7)
            {
                CheckPoint = 8; // Increment the counter
                Debug.Log("Checkpoint reached! Total checkpoints: " + CheckPoint);
                UnityEditor.EditorApplication.isPlaying = false;
                Debug.Log("Game finished!!!!");

            } else if (CheckPoint < 8)
            {
                MissedCheckPoint = CheckPoint + 1;
                Debug.Log("You've missed or gone through another check point. Please go to checkpoint " + MissedCheckPoint);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
