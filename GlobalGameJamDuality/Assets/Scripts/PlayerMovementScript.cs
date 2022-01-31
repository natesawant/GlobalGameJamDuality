using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float maxWalkSpeed, walkAcceleration, maxSprintSpeed, sprintAcceleration, airDrag, jumpForce, jumpCooldown, jumpCurr, groundRadius;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    GameObject model;
    public Animator anim;

    public UniverseHandler uH;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        model = GameObject.Find("characterMedium");
        //anim = model.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkAndSprint();
        Jump();
        SwitchUniverse();
    }

    void WalkAndSprint()
    {
        // check which direction to face
        if (rb.velocity.x >= 1f) {
            model.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (rb.velocity.x <= -1f) {
            model.transform.localRotation = Quaternion.Euler(0, -90, 0);
        }

        // check if moving animation or not
        if (Mathf.Abs(rb.velocity.x) >= 0.2f) {
            anim.SetBool("Run", true);
        }
        else {
            anim.SetBool("Run", false);
        }

        // Airdrag
        if (!isGrounded())
        {
            
        }

        // Walking
        if (Input.GetAxisRaw("Sprint") == 0)
        {
            if (Mathf.Abs(rb.velocity.x) <= maxWalkSpeed)
            {
                rb.AddForce(Input.GetAxisRaw("Horizontal") * walkAcceleration * transform.right * Time.deltaTime);
            }
        }
        // Sprinting
        else
        {
            if (Mathf.Abs(rb.velocity.x) <= maxSprintSpeed)
            {
                rb.AddForce(Input.GetAxisRaw("Horizontal") * sprintAcceleration * transform.right * Time.deltaTime);
            }
        }
    }

    void Jump()
    {
        if (isGrounded() && jumpCurr >= jumpCooldown) {
            anim.SetBool("Jump", false);
        }

        jumpCurr += Time.deltaTime;
        if (Input.GetAxisRaw("Jump") == 1 && isGrounded() && jumpCurr >= jumpCooldown)
        {
            anim.SetBool("Jump", true);
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            Debug.Log("Attempting to jump...");
            rb.AddForce(transform.up * jumpForce);
            jumpCurr = 0;
        }
    }
     void SwitchUniverse(){
         if (Input.GetKeyDown(KeyCode.H)){
            uH.Switch();
         }
     }
    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.transform.position, groundRadius, groundLayer);
    }
}
