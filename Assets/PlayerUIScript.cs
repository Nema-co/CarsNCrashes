using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIScript : MonoBehaviour
{
    Camera PlayerCam;
    Canvas PlayerCanvas;
    TMP_Text PlayerPositionNo;
    playerProgressScript player;

    private int lapNoUI = 1;
    // Start is called before the first frame update
    public void Start()
    {
        player = GetComponent<playerProgressScript>();
        PlayerCam = GetComponent<Camera>(); //TODO: Camera isn't bing picked up correctly.
        PlayerCanvas = PlayerCam.GetComponent<Canvas>();
        PlayerPositionNo = PlayerCanvas.GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    public void updatePlayerPosUI()
    {
        //lapNoUI++;
        PlayerPositionNo.text = player.playerPosition().ToString();
    }
}
