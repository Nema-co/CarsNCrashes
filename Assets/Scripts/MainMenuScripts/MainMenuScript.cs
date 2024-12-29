
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    //Objects found in the scene package! 
    private GameObject sBObject, SplitScreenObj, MultiPlayerObj, OptionsObj, QuitGameObj, playerChoicePopUp;
    private GameObject Map1, Map2;
    private Button sPB, SplitScreenButton, MultiPlayerButton, OptionsButton, QuitGameButton, Map1Button, Map2Button;
    private TMP_Text singlePlayerButtonText, SplitScreenPlayerButtonText, MultiPlayerButtonText, OptionButtonText, QuitGameButtonText;


    //Split Screen PopUp variables
    private GameObject OnePlayer_Obj, TwoPlayer_Obj, ThreePlayer_Obj, FourPlayer_Obj;
    private Button OnePlayer_Button, TwoPlayer_Button, ThreePlayer_Button, FourPlayer_Button;
    private TMP_Text OnePlayer_Text, TwoPlayer_Text, ThreePlayer_Text, FourPlayer_Text;


    void Start()
    {
        sBObject = GameObject.Find("SinglePlayerButton");
        sPB = sBObject.GetComponent<Button>();
        singlePlayerButtonText = sBObject.GetComponentInChildren<TMP_Text>();

        SplitScreenObj = GameObject.Find("SplitScreenButton");
        SplitScreenButton = SplitScreenObj.GetComponent<Button>();
        SplitScreenPlayerButtonText = SplitScreenObj.GetComponentInChildren<TMP_Text>();
            

        MultiPlayerObj = GameObject.Find("MultiPlayerButton");
        MultiPlayerButton = MultiPlayerObj.GetComponent<Button>();
        MultiPlayerButtonText = MultiPlayerObj.GetComponentInChildren<TMP_Text>();


        OptionsObj = GameObject.Find("OptionsButton");
        OptionsButton = OptionsObj.GetComponent<Button>();
        OptionButtonText = OptionsObj.GetComponentInChildren<TMP_Text>();

        QuitGameObj = GameObject.Find("QuitGameButton");
        QuitGameButton = QuitGameObj.GetComponent<Button>();
        QuitGameButtonText = QuitGameObj.GetComponentInChildren<TMP_Text>();

        OnePlayer_Obj = GameObject.Find("1Player");
        OnePlayer_Button = OnePlayer_Obj.GetComponent<Button>();
        OnePlayer_Text = OnePlayer_Obj.GetComponentInChildren<TMP_Text>();
        

        TwoPlayer_Obj = GameObject.Find("2Player");
        TwoPlayer_Button = TwoPlayer_Obj.GetComponent<Button>();
        TwoPlayer_Text = TwoPlayer_Obj.GetComponentInChildren<TMP_Text>();
        

        ThreePlayer_Obj = GameObject.Find("3Player");
        ThreePlayer_Button = ThreePlayer_Obj.GetComponent<Button>();
        ThreePlayer_Text = ThreePlayer_Obj.GetComponentInChildren<TMP_Text>();
        

        singlePlayerButtonText.text = "Single Player";
        SplitScreenPlayerButtonText.text = "Split Screen";
        MultiPlayerButtonText.text = "Multiplayer";
        OptionButtonText.text = "Options";
        QuitGameButtonText.text = "Quit Game";


        //Amount of players button text
        OnePlayer_Text.text = "One Player";
        TwoPlayer_Text.text = "Two Player";
        ThreePlayer_Text.text = "Three Player";

        //Player choice popup!
        playerChoicePopUp = GameObject.Find("playerCountPopUp");
        playerChoicePopUp.SetActive(false);

        Map1 = GameObject.Find("Map1");
        Map1Button = Map1.GetComponent<Button>();
        Map1.SetActive(false);

        Map2 = GameObject.Find("Map2");
        Map2Button = Map2.GetComponent<Button>();
        Map2.SetActive(false);


        //Button click elements
        Map1Button.onClick.AddListener(() => SceneManagerScript.OnSelectMoveToGameScene("Map1"));
        Map2Button.onClick.AddListener(() => SceneManagerScript.OnSelectMoveToGameScene("Map2"));
        sPB.onClick.AddListener(() => OnButtonClickSetPlayerCount(1));
        SplitScreenButton.onClick.AddListener(onSplitScreenButtonClick);
        MultiPlayerButton.onClick.AddListener(onMultiplayerButtonClick);
        OptionsButton.onClick.AddListener(onOptionsButtonClick);
        QuitGameButton.onClick.AddListener(onQuitButtonClick);

        //SplitScreen pop up player selection
        OnePlayer_Button.onClick.AddListener(() => OnButtonClickSetPlayerCount(1));
        TwoPlayer_Button.onClick.AddListener(() => OnButtonClickSetPlayerCount(2));
        //ThreePlayer_Button.onClick.AddListener(() => OnButtonClickSetPlayerCount(3));
    }

    public void onSplitScreenButtonClick()
    {
        playerChoicePopUp.SetActive(true);
    }

    public void onMultiplayerButtonClick()
    {
        MultiPlayerButton.interactable = false;
    }

    public void onOptionsButtonClick()
    {
        OptionsButton.interactable = false;
    }

    public void onQuitButtonClick()
    {
        QuitGameButton.interactable = false;
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void OnButtonClickSetPlayerCount(int playerCount) {
        sBObject.SetActive(false);
        SplitScreenObj.SetActive(false);
        MultiPlayerObj.SetActive(false);
        OptionsObj.SetActive(false);
        QuitGameObj.SetActive(false);
        playerChoicePopUp.SetActive(false);
        Map1.SetActive(true);
        Map2.SetActive(true);

        if (playerCount == 0) {
            SceneManagerScript.ErrorScene("Player count is set to zero.", GlobalVariables.ErrorPage);
        } else if (playerCount > 1) {
            GlobalVariables.isSplitScreen = true;
        } else {
            GlobalVariables.isSplitScreen = false;
        }

        GlobalVariables.PlayerCount = playerCount;
        GlobalVariables.isGameReady = true;
    }
}
