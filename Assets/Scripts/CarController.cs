using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody theRB;

    public float forwardAccel = 0f, reverseAccel =0f, maxSpeed = 0f, turnStrengh = 180;

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = theRB.transform.position;
    }

    private void FixedUpdate()
    {
        theRB.AddForce(transform.forward * forwardAccel);
    }

}
