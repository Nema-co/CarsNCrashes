using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CarMovementObject : MonoBehaviour
{
   // private float speed = 25, reverse = 13;
    public Rigidbody rb;

    private float forward = 8f, backward = 4f, turnStrength = 180, gravityForce = 10f;
    private float speedInput, turnInput = 0;
    private bool grounded;
    public LayerMask whatIsGround;
    private float groundRayLength = 2f;
    public Transform groundRayPoint;
    public int PlayerNum;
    private float vertical;
    private Transform leftWheel;
    private Transform rightWheel;
    private Transform leftWheelRear;
    private Transform rightWheelRear;
    private float maxRotation = 90f;




    // private Vector3 defaultPosition = new Vector3(237.48f, 42, 17); //Default spawn location variable


    // Start is called before the first frame update
    void Start() {
        rb.transform.parent = null; //Will need to remove this logic at some point but remain for now.
       if(PlayerNum == 1)
        {
            //Grabs all components for each player. Must be a better way of dealing with this not yet thought how

            leftWheel = transform.Find("Wheel_FL");
            rightWheel = transform.Find("Wheel_FR");
            leftWheelRear = transform.Find("Wheel_RL");
            rightWheelRear = transform.Find("Wheel_RR");
        }/* else if(PlayerNum == 2) 
        {
           /* vertical = Input.GetAxis("Vertical2");
            turnInput = Input.GetAxis("Horizontal2");
            leftWheel = transform.Find("Wheel_FL2");
            rightWheel = transform.Find("Wheel_FR2");
            leftWheelRear = transform.Find("Wheel_RL2");
            rightWheelRear = transform.Find("Wheel_RR2");
        }*/


    }

    // Update is called once per frame
    void Update() {
        vertical = Input.GetAxis("Vertical1");
        turnInput = Input.GetAxis("Horizontal1");

        speedInput = 0f;
         if (vertical > 0) //uses API logic
        {
            //Debug.Log("First vertial upwards test");
            speedInput = vertical * forward * 100f;
            leftWheel.Rotate(Vector3.right, speedInput * Time.deltaTime);
            rightWheel.Rotate(Vector3.right, speedInput * Time.deltaTime);
            leftWheelRear.Rotate(Vector3.right, -speedInput * Time.deltaTime);
            rightWheelRear.Rotate(Vector3.right, -speedInput * Time.deltaTime);
            //Debug.Log("Second vertial upwards test");


        } else if (vertical < 0) //uses API logic
        {
            //Debug.Log("First vertial down test");
            speedInput = vertical * backward * 100f;
            leftWheel.Rotate(Vector3.left, -speedInput * Time.deltaTime);
            rightWheel.Rotate(Vector3.left, -speedInput * Time.deltaTime);
            leftWheelRear.Rotate(Vector3.left, -speedInput * Time.deltaTime);
            rightWheelRear.Rotate(Vector3.left, -speedInput * Time.deltaTime);
            //Debug.Log("Second vertial down test");
        }
         //DAN LOGIC BELOW NEED ADJUSTMENTS NOT YET FINISHED.
        if (turnInput > 0)
        {
           if (leftWheel.eulerAngles.y >= 0 && leftWheel.eulerAngles.y <= 35 || rightWheel.eulerAngles.y >= 0 && rightWheel.eulerAngles.y <= 35)
           {
                leftWheel.Rotate(Vector3.up, 100f * Time.deltaTime);
                rightWheel.Rotate(Vector3.up, 100f * Time.deltaTime);
           }
        }
        else if (turnInput < 0)
        {
            if (leftWheel.eulerAngles.y <= 0 && leftWheel.eulerAngles.y >= -35 || rightWheel.eulerAngles.y <= 0 && rightWheel.eulerAngles.y >= -35)
            {
                leftWheel.Rotate(Vector3.down, -100f * Time.deltaTime);
                rightWheel.Rotate(Vector3.down, -100f * Time.deltaTime);
            }
        }
        
        //Controls wheel movement left to right automatically (Logic is slightly wrong by looks of it. Will come back to it.
        if(turnInput == 0 && leftWheel.eulerAngles.y > 0)
        {
            leftWheel.Rotate(Vector3.down, -1 * Time.deltaTime);
            rightWheel.Rotate(Vector3.down, -1 * Time.deltaTime);

        } else if (turnInput == 0 && leftWheel.eulerAngles.y < 0)
        {
            leftWheel.Rotate(Vector3.up, 1 * Time.deltaTime);
            rightWheel.Rotate(Vector3.up, 1 * Time.deltaTime);
        }


        // if (wheelSpeed > maxRotation)
        //{
        // leftWheel.transform.eulerAngles = new Vector3(0, 0, 0);
        //Need to figure out how I code the wheel logic into one. Will look at this another day! Work in progress
        // }

        if (grounded) //Only works if ground has the layer marked (grounded) as it uses a public variable
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
                /*if(distance > 300 && !grounded)
                {
                  Debug.LogError("Distance to ground appears above 300: " + distance);
                  rb.transform.position = new Vector3(239.96f, 42f, 13.44f);
                }*/
                
            }
        }
        Debug.DrawRay(groundRayPoint.position, -transform.up * groundRayLength, Color.red);
    }
}
