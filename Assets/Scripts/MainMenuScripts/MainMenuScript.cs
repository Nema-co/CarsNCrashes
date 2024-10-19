using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    //Objects found in the scene package! 
    private GameObject sBObject, SplitScreenObj, MultiPlayerObj, OptionsObj, QuitGameObj, playerChoicePopUp;
    private Button sPB, SplitScreenButton, MultiPlayerButton, OptionsButton, QuitGameButton;
    public TMP_Text singlePlayerButtonText, SplitScreenPlayerButtonText, MultiPlayerButtonText, OptionButtonText, QuitGameButtonText;
    
    
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


        singlePlayerButtonText.text = "Single Player";
        SplitScreenPlayerButtonText.text = "Split Screen";
        MultiPlayerButtonText.text = "Multiplayer";
        OptionButtonText.text = "Options";
        QuitGameButtonText.text = "Quit Game";


        singlePlayerButtonText.color = Color.white;
        SplitScreenPlayerButtonText.color = Color.white;
        MultiPlayerButtonText.color = Color.white;
        OptionButtonText.color = Color.white;
        QuitGameButtonText.color = Color.white;

        //Player choice popup!
        playerChoicePopUp = GameObject.Find("playerCountPopUp");
        playerChoicePopUp.SetActive(false);

        //Button click elements
        sPB.onClick.AddListener(() => SceneManagerScript.OnSelectMoveToGameScene(1));
        SplitScreenButton.onClick.AddListener(onSplitScreenButtonClick);
        MultiPlayerButton.onClick.AddListener(onMultiplayerButtonClick);
        OptionsButton.onClick.AddListener(onOptionsButtonClick);
        QuitGameButton.onClick.AddListener(onQuitButtonClick);
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
        Application.Quit();
    }
}
