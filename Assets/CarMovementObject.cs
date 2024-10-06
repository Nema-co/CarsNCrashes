using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementObject : MonoBehaviour
{
   // private float speed = 25, reverse = 13;
    public Rigidbody rb;

    private float forward = 8f, backward = 4, turnStrength = 180, gravityForce = 10f;
    public float speedInput, turnInput;
    private bool grounded;
    public LayerMask whatIsGround;
    private float groundRayLength = 2f;
    public Transform groundRayPoint;
    public int PlayerNum;
    private float vertical;
    

    // private Vector3 defaultPosition = new Vector3(237.48f, 42, 17); //Default spawn location variable


    // Start is called before the first frame update
    void Start() {

        rb.transform.parent = null; //Will need to remove this logic at some point but remain for now.
         
    }

    // Update is called once per frame
    void Update() {
        
        if(PlayerNum == 1)
        {
            vertical = Input.GetAxis("Vertical1");
            turnInput = Input.GetAxis("Horizontal1");
        } else if (PlayerNum == 2) {
            vertical = Input.GetAxis("Vertical2");
            turnInput = Input.GetAxis("Horizontal2");
        }


         speedInput = 0f;
         if (vertical > 0)
         {
            speedInput = vertical * forward * 100f;
            
        } else if (vertical < 0)
        {
            speedInput = vertical * backward * 100f;
        }


         
        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * vertical, 0f));
        }
            transform.position = rb.transform.position;
    }

    public void FixedUpdate() {

        grounded = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround)) {
           grounded = true;
        }

        if (grounded) {
            //Debug.Log("Player is grounded.");
            if (Mathf.Abs(speedInput) > 0)
            {
                rb.AddForce(transform.forward * speedInput);
               // Debug.Log("Object is grounded.");
            }
        } else {
            {
                rb.AddForce(Vector3.up * -gravityForce * 50f);
                //Debug.Log("Is Not Grounded.");
                float distance = Vector3.Distance(groundRayPoint.position, hit.point);
                if(distance > 300 && !grounded)
                {
                // Debug.LogError("Distance to ground appears above 300: " + distance);
                    // rb.transform.position = new Vector3(239.96f, 42f, 13.44f);
                }
                
            }
        }
        Debug.DrawRay(groundRayPoint.position, -transform.up * groundRayLength, Color.red);
    }
}
