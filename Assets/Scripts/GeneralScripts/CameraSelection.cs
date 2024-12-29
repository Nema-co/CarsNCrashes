using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using TMPro.Examples;
using static UnityEditor.IMGUI.Controls.CapsuleBoundsHandle;
using UnityEditor.Experimental.GraphView;

public class CameraSelection : MonoBehaviour
{
    // Start is called before the first frame upda
    private Camera playerCam, mainCam;
    private GameObject mainCameraObj;

    private float XAxis, YAxis, WidthAxis, HeightAxis;
    void Awake() { //TODO: Need to rewrite this camera selection to use one camera but set the camera values.
        GameObject[] playerCameras = GameObject.FindGameObjectsWithTag("PlayerCamera");
        //GameObject[] mainCamera = GameObject.FindGameObjectsWithTag("MainCamera");
        playerCam = GetComponentInChildren<Camera>();
        playerCam.transform.localRotation = Quaternion.Euler(20, 0, 0);
            //new Vector3(20, 0, 0);
        if (GlobalVariables.isSplitScreen == false) { //Means it'll use main camera only 
            XAxis = 0;
            YAxis = 0;
            WidthAxis = 1f;
            HeightAxis = 1f;
            Debug.Log("Field of view check 1 :" + playerCam.fieldOfView);
            Debug.Log("Field of view check 2 :" + playerCam.fieldOfView);
            playerCam.fieldOfView = 80;
            playerCam.rect = new Rect(XAxis, YAxis, WidthAxis, HeightAxis);
        }  else {
            for (int i = 0; i < playerCameras.Length; i++) {
                if (GlobalVariables.PlayerCount <= 2) {
                    if (i == 0) {
                        XAxis = 0;
                        YAxis = 0f;
                        WidthAxis = 1f;
                        HeightAxis = 0.5f;
                    } else if (i == 1) {
                        XAxis = 0;
                        YAxis = 0.5f;
                        WidthAxis = 1f;
                        HeightAxis = 0.5f;
                    }
                } else {
                    //Needs to be for when there is four players
                }
                playerCam = playerCameras[i].GetComponent<Camera>();
                playerCam.fieldOfView = 80;
                playerCam.rect = new Rect(XAxis, YAxis, WidthAxis, HeightAxis);
            }
            
        }
        
    }

}
