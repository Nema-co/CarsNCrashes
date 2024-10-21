using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private static string SceneSelected { get; set; }
    

    public static void OnSelectReloadScene() {
        SceneSelected = SceneManager.GetActiveScene().name;
       SceneManager.LoadScene(SceneSelected);
    }
        
    public static void OnSelectMoveToGameScene(int num) {

        int RandomNum = Random.Range(1, 3);
        if(num == 0) {
            ErrorScene("Player count is set to zero.", GlobalVariables.ErrorPage);
        } else if(num > 1) {
            GlobalVariables.isSplitScreen = true;
        } else {
            GlobalVariables.isSplitScreen = false;
        }

        GlobalVariables.PlayerCount = num;
        GlobalVariables.isGameReady = true;
        switch (RandomNum) {
            case 1:
                SceneSelected = "Map1Scene";
                break;
            case 2:
                SceneSelected = "Map2";
                break;
            case 3:
                Debug.Log("Scene 3");
                break;
            case 4:
                Debug.Log("Scene 4");
                break;
            case 5:
                Debug.Log("Scene 5");
                break;
            case 6:
                Debug.Log("Scene 6");
                break;
            case 7:
                Debug.Log("Scene 7");
                break;
            case 8:
                Debug.Log("Scene 8");
                break;
            case 9:
                Debug.Log("Scene 9");
                break;
            case 10:
                Debug.Log("Scene 10");
                break;
            default:
                GlobalVariables.ErrorMessage = "Random number generated out of bounds, must be 1 to 10 only.";
                ErrorScene(GlobalVariables.ErrorMessage, GlobalVariables.ErrorPage);
                break;                        
        }
        if(SceneSelected != null) { 
            SceneManager.LoadScene(SceneSelected);
        } else {
            GlobalVariables.ErrorMessage = "The map randomly selected appears to not exist. Please try again and report bug to Developers.";
            ErrorScene(GlobalVariables.ErrorMessage, GlobalVariables.ErrorPage);
        }
    }


    /* public IEnumerator OnSelectLoadAsync(string sceneName) {

         AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

         return OnSelectReloadScene("Map1Scene");
     }*/


    public static void ExitBackToMainPage()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void ErrorScene(string Message, string ErrorScene)
    {

        if (Message != null) {
            GlobalVariables.ErrorMessage = Message;
            SceneManager.LoadScene(ErrorScene);
        }
    }
}
