using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using TMPro.Examples;

public class playerChoiceHandler : MonoBehaviour
{

    private GameObject OnePlayer_Obj, TwoPlayer_Obj, ThreePlayer_Obj, FourPlayer_Obj;
    private Button OnePlayer_Button, TwoPlayer_Button, ThreePlayer_Button, FourPlayer_Button;
    private TMP_Text OnePlayer_Text, TwoPlayer_Text, ThreePlayer_Text, FourPlayer_Text;
    private GameObject[] CheckPoints;

    // Start is called before the first frame update
    void Start()
    {
        OnePlayer_Obj = GameObject.Find("1Player");
        OnePlayer_Button = OnePlayer_Obj.GetComponent<Button>();
        OnePlayer_Text = OnePlayer_Obj.GetComponentInChildren<TMP_Text>();
        OnePlayer_Text.text = "One Player";

        TwoPlayer_Obj = GameObject.Find("2Player");
        TwoPlayer_Button = TwoPlayer_Obj.GetComponent<Button>();
        TwoPlayer_Text = TwoPlayer_Obj.GetComponentInChildren<TMP_Text>();
        TwoPlayer_Text.text = "Two Player";

        ThreePlayer_Obj = GameObject.Find("3Player");
        ThreePlayer_Button = ThreePlayer_Obj.GetComponent<Button>();
        ThreePlayer_Text = ThreePlayer_Obj.GetComponentInChildren<TMP_Text>();
        ThreePlayer_Text.text = "Three Player";


        OnePlayer_Button.onClick.AddListener(() => OnButtonClick(1));
        TwoPlayer_Button.onClick.AddListener(() => OnButtonClick(2));
        ThreePlayer_Button.onClick.AddListener(() => OnButtonClick(3));



        OnePlayer_Text.color = Color.white;
        TwoPlayer_Text.color = Color.white;
        ThreePlayer_Text.color = Color.white;

    }

    // Update is called once per frame
     public void OnButtonClick(int num)
     {
        GlobalVariables.PlayerCount = num;
        if(num == 1)
        {
            //GlobalVariables.OnlyOnePlayer = true;
            GlobalVariables.isSplitScreen = false;
        } else
        {
            GlobalVariables.isSplitScreen = true;
        }
        MainMenuScript.onMapLoading();
        //SceneManager.LoadScene("Map1Scene
    }
}
