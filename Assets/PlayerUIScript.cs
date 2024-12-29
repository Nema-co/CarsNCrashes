using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerUIScript : MonoBehaviour
{
    Camera PlayerCam;
    Canvas PlayerCanvas;
    TMP_Text PlayerPositionNo;
    playerProgressScript playerScript;
    GameObject playerColliderObj;

    private int lapNoUI = 1;
    // Start is called before the first frame update
    public void Start() {
        playerColliderObj = GameObject.FindWithTag("PlayerCollider"); //TODO: Not happy with this way of grabbing object inside parent object
        if (playerColliderObj != null) {
            playerScript = playerColliderObj.GetComponentInChildren<playerProgressScript>();
            if (playerScript != null) {
                PlayerCam = GetComponentInChildren<Camera>();
                if (PlayerCam != null) {
                    PlayerCanvas = PlayerCam.GetComponentInChildren<Canvas>();
                    if (PlayerCanvas != null) {
                        PlayerPositionNo = PlayerCanvas.GetComponentInChildren<TMP_Text>();
                        if (PlayerPositionNo != null) {
                            updatePlayerPosUI();
                            PlayerPositionNo.fontSizeMin = 10;
                            PlayerPositionNo.fontSizeMax = 14;
                        } else {
                            GlobalVariables.ErrorMessage = "Player UI canvas is missing.";
                            SceneManagerScript.ErrorScene(GlobalVariables.ErrorMessage, GlobalVariables.ErrorPage);
                        }
                    } else {
                        GlobalVariables.ErrorMessage = "Player UI canvas is missing.";
                        SceneManagerScript.ErrorScene(GlobalVariables.ErrorMessage, GlobalVariables.ErrorPage);
                    }
                } else {
                    GlobalVariables.ErrorMessage = "Player camera is missing.";
                    SceneManagerScript.ErrorScene(GlobalVariables.ErrorMessage, GlobalVariables.ErrorPage);
                }
            } else {
                GlobalVariables.ErrorMessage = "Failed due to player progress script is not detectable";
                SceneManagerScript.ErrorScene(GlobalVariables.ErrorMessage, GlobalVariables.ErrorPage);
            }
        } else {
            GlobalVariables.ErrorMessage = "Player collider object missing, name should be: PlayerCollider";
            SceneManagerScript.ErrorScene(GlobalVariables.ErrorMessage, GlobalVariables.ErrorPage);
        }
    }

    public void updatePlayerPosUI()  {
        //lapNoUI++;
        PlayerPositionNo.text = "Position: " + playerScript.playerPosition().ToString();
        ///PlayerPositionNo.p
        //Debug.Log("Player Pos Check: " + playerScript.playerPosition().ToString());
    }
}
