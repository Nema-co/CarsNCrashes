using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectObject : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform Sphere;

    void Start()
    {
        Sphere = transform.Find("Player1");
        Sphere.transform.position = new Vector3(233.38f, 41.50f, 12.57f);
        Debug.Log("Car Position: " + transform.position);
        Debug.Log("Sphere Position: " + Sphere.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Sphere.position;
        transform.rotation = Sphere.rotation;


    }
}
