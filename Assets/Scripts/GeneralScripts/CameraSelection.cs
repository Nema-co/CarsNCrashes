using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using TMPro.Examples;

public class CameraSelection : MonoBehaviour
{
    // Start is called before the first frame upda
    private Camera playerCam, mainCam;
    private GameObject mainCameraObj;
    void Awake()
    { //TODO: Need to rewrite this camera selection to use one camera but set the camera values.
        GameObject[] playerCameras = GameObject.FindGameObjectsWithTag("PlayerCamera");
        GameObject[] mainCamera = GameObject.FindGameObjectsWithTag("MainCamera");
        
        if (GlobalVariables.isSplitScreen == false) //Means it'll use main camera only
        {
            int MainCameraEnabled = mainCamera.Length;

            if (MainCameraEnabled >= 1) 
            {
                for (int i = 0; i < playerCameras.Length; i++)
                {
                    playerCam = playerCameras[i].GetComponent<Camera>();
                    playerCam.enabled = false;
                }
            } 
        } else {
            mainCameraObj = GameObject.Find("MainCamera");
            mainCam = mainCameraObj.GetComponent<Camera>();
            mainCam.enabled = false;
        }
    }
}
