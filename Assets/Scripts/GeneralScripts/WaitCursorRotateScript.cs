using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitCursorRotateScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isRunning;
    private float HitCount = 5f, CurrentCount = 0, CountSpinSpeed = 300f;
 
    void Start()
    {
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning == true) {
            if(HitCount > 0) {
                transform.Rotate(Vector3.back, CountSpinSpeed * Time.deltaTime);
                HitCount -= 1f * Time.deltaTime;
            } else {
                SceneManager.LoadScene("Map1Scene");
            }
        }


            //(RectTransform.Rotation.x, RectTransform.Rotation.y, 0.3f * Time.DeltaTime);
    }
}
