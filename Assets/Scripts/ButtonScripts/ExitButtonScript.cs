using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    //private Button Test;
    void Start()
    {
        GameObject ExitButtonObj = GameObject.Find("ExitButton");
        Button ExitButton = ExitButtonObj.GetComponent<Button>();
        //TMP_Text ExitButtonTech = ExitButtonObj.GetComponentInChildren<TMP_Text>();
        ExitButtonObj.SetActive(true);
        ExitButton.onClick.AddListener(SceneManagerScript.ExitBackToMainPage);
       // ExitButton.text
    }
}
