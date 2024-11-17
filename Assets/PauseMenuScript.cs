using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class PauseMenuScript : MonoBehaviour
{
    private static bool isGamePaused = false;
    private static GameObject PauseMenu, ResumeButtonObj, OptionsButtonObj, QuitButtonObj;
    private Button Resume, Options, Quit;

    public void Start() {
        PauseMenu = GameObject.Find("PauseMenuPanel");

        ResumeButtonObj = GameObject.Find("ResumeButton");
        Resume = ResumeButtonObj.GetComponent<Button>();
        Resume.onClick.AddListener(resumeGame);

        if (Resume != null) {
            
        } else
        {
            Debug.Log("Resume button is null");
        }
        //OptionsButtonObj = GameObject.Find("OptionsButton");
        // Options = OptionsButtonObj.GetComponent<Button>();
        //Options.onClick.AddListener();

        QuitButtonObj = GameObject.Find("QuitButton");
        Quit = QuitButtonObj.GetComponent<Button>();
        Quit.onClick.AddListener(SceneManagerScript.ExitBackToMainPage);

        PauseMenu.SetActive(false);
       
    }

    public void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            //Pauses game but does not unpause until I build UI and look at whether we want it as a shortkey.
            //Need to add a multiplayer variable here at some point to combat pausing all movement if you play multiplayer.
            if (isGamePaused == false) {
                pauseGame();
            } else {  
                resumeGame();
            }
        }
    }

    public void resumeGame() {
        Time.timeScale = 1f;
        isGamePaused = false;
        PauseMenu.SetActive(false);
        Debug.Log("Resume game!");
    }

    public void pauseGame() {
        Time.timeScale = 0f;
        isGamePaused = true;
        PauseMenu.SetActive(true);
        Debug.Log("Paused game!");

    }
}
