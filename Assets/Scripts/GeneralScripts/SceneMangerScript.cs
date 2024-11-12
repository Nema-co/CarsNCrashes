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
        
    public static void OnSelectMoveToGameScene(string map) {
        if(map != null) { 
            SceneManager.LoadScene(map);
        } else {
            GlobalVariables.ErrorMessage = "The map selected appears to not be configured correctly, Dev error.";
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
