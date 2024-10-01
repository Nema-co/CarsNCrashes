using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkSphere : MonoBehaviour
{
    // Start is called before the first frame update

    private SphereCollider LinkedCarSphere;
    void Start()
    {
       // LinkedCarSphere = GetComponentInChildren<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = LinkedCarSphere.transform.position;
        
    }
}
