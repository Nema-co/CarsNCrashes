using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ErrorPagePanelScript : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

        GameObject HeaderPanel = GameObject.Find("ErrorHeadPanel");
        TMP_Text ErrorHeaderText = HeaderPanel.GetComponentInChildren<TMP_Text>();


        GameObject DescPanel = GameObject.Find("ErrorDescBox");
        TMP_Text ErrorDescText = DescPanel.GetComponentInChildren<TMP_Text>();



        ErrorHeaderText.text = "ERROR MESSAGE";

        if (ErrorDescText != null) {
            ErrorDescText.text = GlobalVariables.ErrorMessage;
        } else {
            throw new System.Exception("System Error!");
        }
    }
}
