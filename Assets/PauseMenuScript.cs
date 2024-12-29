using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class PauseMenuScript : MonoBehaviour
{
    private static bool isGamePaused = false;
    public static GameObject PauseMenu, ResumeButtonObj, OptionsButtonObj, QuitButtonObj;
    private Button Resume, Options, Quit;


    public void Awake()
    {
        PauseMenu = GameObject.Find("PauseMenuPanel");
    }

    public void Start() {
        ResumeButtonObj = GameObject.Find("ResumeButton");
        Resume = ResumeButtonObj.GetComponent<Button>();

        if (Resume != null) {
            Resume.onClick.AddListener(resumeGame);
        } else
        {
            Debug.Log("Resume button is null");
        }
        //OptionsButtonObj = GameObject.Find("OptionsButton");
        //Options = OptionsButtonObj.GetComponent<Button>();
       // Options.onClick.AddListener();

        QuitButtonObj = GameObject.Find("QuitButton");
        Quit = QuitButtonObj.GetComponent<Button>();
        Quit.onClick.AddListener(quitGame);
        PauseMenu.SetActive(false);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //Pauses game and unpauses.
            if (isGamePaused == false) {
                pauseGame();
            } else {  
                resumeGame();
            }
        }
    }

    public void resumeGame() {
        PauseMenu.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1f;
        Debug.Log("Resume game!");
    }

    public void pauseGame() {
        PauseMenu.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
        Debug.Log("Paused game!");

    }

    public void quitGame() {
        isGamePaused = false;
        Time.timeScale = 1f;
        SceneManagerScript.ExitBackToMainPage();

    }
}
