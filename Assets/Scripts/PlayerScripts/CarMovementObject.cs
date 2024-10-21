using UnityEngine;

public class CarMovementObject : MonoBehaviour
{
   // private float speed = 25, reverse = 13;
    public Rigidbody rb;

    private float forward = 25f, backward = 4f, turnStrength = 180, gravityForce = 10f, dragOnGround = 3f;
    public float speedInput, turnInput = 0;
    private bool grounded;
    public LayerMask whatIsGround;
    public float groundRayLength = 0.5f;
    public Transform groundRayPoint;
    private float vertical;
    public Transform leftWheel, rightWheel, leftWheelRear, rightWheelRear;
    private float MaxTurn = 35;
    public int PlayerNum;



    // Start is called before the first frame update
    void Start() {
        rb.transform.parent = null; //Will need to remove this logic at some point but remain for now.
    }

    // Update is called once per frame
    void Update() {
        if (GlobalVariables.isGameReady == true)
        {
            if(GlobalVariables.isGamePaused == false) { 
                if (GlobalVariables.isSplitScreen == true)
                {
                    if (PlayerNum == 1) {
                        vertical = Input.GetAxis("Vertical1");
                        turnInput = Input.GetAxis("Horizontal1");
                    } else if (PlayerNum == 2) {
                            vertical = Input.GetAxis("Vertical2");
                            turnInput = Input.GetAxis("Horizontal2");
                        } else {
                                throw new System.Exception("No player number set, so no API inputs setup.");
                        }
            } else if (PlayerNum == 1) {
                vertical = Input.GetAxis("Vertical");
                turnInput = Input.GetAxis("Horizontal");
            }

            speedInput = 0f;
            if (vertical > 0) {
                speedInput = vertical * forward * 100f;

            }
            if (vertical < 0) {
                speedInput = vertical * backward * 75f;
            }

            if (grounded) //Only works if ground has the layer marked (grounded) as it uses a public variable
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * vertical, 0f));

            }

            leftWheel.localRotation = Quaternion.Euler(leftWheel.localRotation.eulerAngles.y, (turnInput * MaxTurn) - 180, leftWheel.localRotation.eulerAngles.z);
            rightWheel.localRotation = Quaternion.Euler(rightWheel.localRotation.eulerAngles.y, turnInput * MaxTurn, rightWheel.localRotation.eulerAngles.z);
            transform.position = rb.transform.position;
            }
        } else
        {
            SceneManagerScript.ExitBackToMainPage();
            Debug.Log("Game not ready will be taken back to main menu.");
        }
    }

    public void FixedUpdate()
    {

        grounded = false;
        RaycastHit hit;

        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {// Create ray cast object in editor then link it by the following and link the ray length
            grounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (grounded)
        {
            rb.drag = dragOnGround;
            if (Mathf.Abs(speedInput) > 0)
            {
                rb.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            rb.drag = 0.1f;
            rb.AddForce(Vector3.up * -gravityForce * 200f);
            float distance = Vector3.Distance(groundRayPoint.position, hit.point);
        }
        Debug.DrawRay(groundRayPoint.position, -transform.up * groundRayLength, Color.red);
    }
}
