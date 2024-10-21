using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefaultButtonStylingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] ButtonStyler = GameObject.FindGameObjectsWithTag("Button");
        for(int i = 0; i < ButtonStyler.Length; i++) {
            Image Button_img = ButtonStyler[i].GetComponent<Image>();
            TMP_Text Button_txt = ButtonStyler[i].GetComponentInChildren<TMP_Text>();
            Button_img.color = new Color(0.7686275f, 0.4980392f, 1f);
            Button_txt.color = Color.white;
        }
    }
}
