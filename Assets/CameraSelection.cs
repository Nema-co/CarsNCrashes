using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelection : MonoBehaviour
{
    // Start is called before the first frame upda
    void Start()
    {
        GameObject[] playerCameras = GameObject.FindGameObjectsWithTag("PlayerCamera");
        GameObject[] mainCamera = GameObject.FindGameObjectsWithTag("MainCamera");

        int MainCameraEnabled = mainCamera.Length;

        if (MainCameraEnabled >= 1)
        {
            for (int i = 0; i < playerCameras.Length; i++)
            {
                Camera playerCam = playerCameras[i].GetComponent<Camera>();
                playerCam.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
