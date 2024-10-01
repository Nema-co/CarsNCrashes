using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody theRB;

    public float forwardAccel, reverseAccel, maxSpeed, turnStrengh;

    // Start is called before the first frame update
    void Start() {
            if(Input.GetKey(KeyCode.W)) {
            Debug.Log("Forward test");
            transform.position += new Vector3 (1, 2, 3);
        }
    }

    // Update is called once per frame
    private void Update() {
    }

    private void FixedUpdate()
    {
        //theRB.AddForce(transform.forward * forwardAccel);
    }

}
