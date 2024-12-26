using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject[] playerObj;
    private Collider playerCollider;

    //Original variables
    private GameObject Vehicle1, Vehicle2;
    public GameObject[] CheckPoints;
    public static int PlayerCount;


    public void Awake()
    {
        playerObj = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < playerObj.Length; i++) {
            playerProgressScript PlayerProgressScript = playerObj[i].GetComponent<playerProgressScript>();
            //playerProgressScript ScriptAttached = playerCollider.GetComponent<playerProgressScript>();
            if ((PlayerProgressScript == null)) {
                Debug.LogError("Player progress script not attached to parent object: " + playerObj[i].name);

            }
        }
    }

    public void Start() {
        Vehicle1 = GameObject.Find("Vehicle1");
        Vehicle2 = GameObject.Find("Vehicle2");

        PlayerCount = GlobalVariables.PlayerCount;
        if (PlayerCount == 0){
            Debug.LogError("MaxPlayer count is zero. Will first send you back to main menu. (Will most likely only be in test phase)");
            SceneManager.LoadScene("MainMenu");
        } else {
            Debug.Log("Max player count: " + PlayerCount);
            if (GlobalVariables.isSplitScreen == false) {
                /* We'll look to build a logic to cycle through all game objects named vechicle and when a user selects one it grabs that one and adds a default location
                 * but not now */
                Vehicle2.SetActive(false); //Test for now 
            } else {
                Vehicle1.SetActive(true);
                Vehicle2.SetActive(true);
            }
        }

        CheckPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        GlobalVariables.MaxCheckPointCount = CheckPoints.Length;
        for (int i = 0; i < GlobalVariables.MaxCheckPointCount; i++) {
            GameCheckPoints CurrentObj = CheckPoints[i].GetComponent<GameCheckPoints>();
            if (CurrentObj != null) {
                if (CurrentObj.CheckPointNumber > GlobalVariables.MaxCheckPointCount || CurrentObj.CheckPointNumber == 0) {
                    GlobalVariables.ErrorMessage = " A checkpoint has a number of: " + CurrentObj.CheckPointNumber + " which is either not set or higher than the amount of check points that exist. Check point count; " + GlobalVariables.MaxCheckPointCount;
                    SceneManagerScript.ErrorScene(GlobalVariables.ErrorMessage, GlobalVariables.ErrorPage); 
                }
            } else {
                GlobalVariables.ErrorMessage = "GameCheckPoints script is missing from CheckPoint script or object has wrong object tag.";
                SceneManagerScript.ErrorScene(GlobalVariables.ErrorMessage, GlobalVariables.ErrorPage);
            }
        }
        
        Debug.Log("How many check points exist: " + GlobalVariables.MaxCheckPointCount);
    }


    public static void playerWinsGame()
    {
        Debug.Log("Game finished!!!!");
        SceneManagerScript.ExitBackToMainPage();
        //UnityEditor.EditorApplication.isPlaying = false; 

    }

}
