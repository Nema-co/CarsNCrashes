using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementObject : MonoBehaviour
{
   // private float speed = 25, reverse = 13;
    public Rigidbody rb;

    private float forward = 8f, backward = 4, speed = 50, turnStrength = 180, gravityForce = 10f;
    public float speedInput, turnInput;
    private bool grounded;
    public LayerMask whatIsGround;
    private float groundRayLength = 2f;
    public Transform groundRayPoint;
    

    // private Vector3 defaultPosition = new Vector3(237.48f, 42, 17); //Default spawn location variable


    // Start is called before the first frame update
    void Start() {
        //transform.position = defaultPosition; //Sets default span location once scene has started
        rb.transform.parent = null;

    }

    // Update is called once per frame
    void Update() {

         speedInput = 0f;
         if (Input.GetAxis("Vertical") > 0)
         {
            speedInput = Input.GetAxis("Vertical") * forward * 300f;
         }
         else if (Input.GetAxis("Vertical") < 0)
         {
            speedInput = Input.GetAxis("Vertical") * backward * 300f;
         }


         turnInput = Input.GetAxis("Horizontal");
        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
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
            Debug.Log("Player is grounded.");
            if (Mathf.Abs(speedInput) > 0)
            {
                rb.AddForce(transform.forward * speedInput);
                Debug.Log("Dan Test Gravity! Speed input");
            }
        } else {
            {
                rb.AddForce(Vector3.up * -gravityForce * 50f);
                Debug.Log("Dan Test Gravity!");
                float distance = Vector3.Distance(groundRayPoint.position, hit.point);
                Debug.Log("Distance to ground: " + distance);
            }
        }
        Debug.DrawRay(groundRayPoint.position, -transform.up * groundRayLength, Color.red);
    }
}
