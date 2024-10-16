using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ErrorPopUpMenuScript : MonoBehaviour
{
  
    public static void ErrorPopUp(string Message, string ErrorScene) {

        if(Message != null) {
            GlobalVariables.ErrorMessage = Message;
            SceneManager.LoadScene(ErrorScene);
        }
    }
}
