using Unity;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject Vehicle1, Vehicle2;

    void Start()
    {
        Vehicle1 = GameObject.Find("Vehicle1");
        Vehicle2 = GameObject.Find("Vehicle2");
        Debug.Log(GlobalVariables.isSplitScreen);
        if (GlobalVariables.isSplitScreen == false)
        {
            /* We'll look to build a logic to cycle through all game objects named vechicle and when a user selects one it grabs that one and adds a default location
             * but not now */
            Vehicle2.SetActive(false); //Test for now
        } else
        {
            Vehicle1.SetActive(true);
            Vehicle2.SetActive(true);
        }
    }

}
