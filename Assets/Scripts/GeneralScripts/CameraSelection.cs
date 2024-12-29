using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using TMPro.Examples;
using static UnityEditor.IMGUI.Controls.CapsuleBoundsHandle;

public class CameraSelection : MonoBehaviour
{
    // Start is called before the first frame upda
    private Camera playerCam, mainCam;
    private GameObject mainCameraObj;

    private float XAxis, YAxis, WidthAxis, HeightAxis;
    void Awake() { //TODO: Need to rewrite this camera selection to use one camera but set the camera values.
        GameObject[] playerCameras = GameObject.FindGameObjectsWithTag("PlayerCamera");
        GameObject[] mainCamera = GameObject.FindGameObjectsWithTag("MainCamera");
        playerCam = GetComponentInChildren<Camera>();
        playerCam.transform.localRotation = Quaternion.Euler(20, 0, 0);
            //new Vector3(20, 0, 0);
        if (GlobalVariables.isSplitScreen == false) { //Means it'll use main camera only 
            XAxis = 0;
            YAxis = 0;
            WidthAxis = 1f;
            HeightAxis = 1f;
            Debug.Log("Field of view check 1 :" + playerCam.fieldOfView);
            playerCam.fieldOfView = 80;
            Debug.Log("Field of view check 2 :" + playerCam.fieldOfView);

           /* int MainCameraEnabled = mainCamera.Length;

            if (MainCameraEnabled > 1) 
            {
                for (int i = 0; i < playerCameras.Length; i++)
                {
                    playerCam = playerCameras[i].GetComponent<Camera>();
                    playerCam.enabled = false;
                }
            }*/
        }  else {
            /*mainCameraObj = GameObject.Find("MainCamera");
            mainCam = mainCameraObj.GetComponent<Camera>();
            mainCam.enabled = false;*/
            XAxis = 0;
            YAxis = 0;
            WidthAxis = 1f;
            HeightAxis = 0.5f;
            Debug.Log("Field of view check 1 :" + playerCam.fieldOfView);
            playerCam.fieldOfView = 80;
            Debug.Log("Field of view check 2 :" + playerCam.fieldOfView);

        }
        playerCam.rect = new Rect(XAxis, YAxis, WidthAxis, HeightAxis);
    }

}
