using System;
using Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject[] Test;
    private Collider Test2;

    //Original variables
    private GameObject Vehicle1, Vehicle2;
    private GameObject[] CheckPoints;
    public static int PlayerCount;


    void Awake()
    {

        Test = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < Test.Length; i++) {
            Test2 = Test[i].GetComponent<Collider>();
            playerProgressScript ScriptAttached = Test2.GetComponent<playerProgressScript>();
            if ((ScriptAttached == null)) {
                GlobalVariables.ErrorMessage = "Player progress script not attached to a player collider object.";
                SceneManagerScript.ErrorScene(GlobalVariables.ErrorMessage, GlobalVariables.ErrorPage);
            }
        }
    }

    void Start() {
        Vehicle1 = GameObject.Find("Vehicle1");
        Vehicle2 = GameObject.Find("Vehicle2");
        Debug.Log(GlobalVariables.isSplitScreen);

        CheckPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        for (int i = 1; i <= CheckPoints.Length; i++) {
               GlobalVariables.MaxCheckPointCount = i;
        }
        Debug.Log("How many check points exist: " + GlobalVariables.MaxCheckPointCount);

        PlayerCount = GlobalVariables.PlayerCount;
        if (PlayerCount == 0) {
            Debug.LogError("MaxPlayer count is zero. Will first send you back to main menu. (Will most likely only be in test phase)");
            SceneManager.LoadScene("MainMenu");
        } else {
            Debug.Log("Max player count: " + PlayerCount);
            if (GlobalVariables.isSplitScreen == false) {
                /* We'll look to build a logic to cycle through all game objects named vechicle and when a user selects one it grabs that one and adds a default location
                 * but not now */
                Vehicle2.SetActive(false); //Test for now
            }
            else {
                Vehicle1.SetActive(true);
                Vehicle2.SetActive(true);
            }
          }

    }

    public static void playerWinsGame()
    {
        Debug.Log("Game finished!!!!");
        UnityEditor.EditorApplication.isPlaying = false;

    }

}
