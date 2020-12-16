using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;
    public float groundDist = 0.4f;
    public LayerMask groundMask;

    CharacterController controller;
    Transform GroundCheck;
    Animation cameraAnim;
    Vector3 move, jumpInnert = Vector3.zero;
    bool isGrounded, inAir;
    float verticalvelocity = 0;

    void Start()
    {
        GroundCheck = GameObject.Find("Player/GroundCheck").transform;
        controller = gameObject.GetComponent<CharacterController>();
        cameraAnim = GameObject.Find("Player/CameraHolder").GetComponent<Animation>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDist, groundMask);

        if (isGrounded)
        {
            verticalvelocity = -2f;
        }
        else
        {
            inAir = true;
        }

        handleMovement();
    }

    public void handleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        move = transform.right * horizontal + transform.forward * vertical;

        //jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            verticalvelocity = Mathf.Sqrt(jumpForce * -2 * gravity);
        }

        verticalvelocity += gravity * Time.deltaTime;

        #region climbing not available now
        //climbing
        /*
        if (onFrontWall)
        {
            if (Input.GetButton("Run") && vertical > 0)
            {
                if (!climbing && canclimb)
                {
                    elapsed = Time.time;
                    climbing = true;
                    canclimb = false;
                }
                else
                {
                    if (Time.time - elapsed <= 1f)
                    {
                        verticalvelocity += climbforce;
                    }
                    else
                    {
                        climbing = false;
                    }
                }
            }
            if (Input.GetButtonUp("Run"))
            {
                climbing = false;
            }
        }
        */
        #endregion

        //just grounded
        if (isGrounded && inAir)
        {
            cameraAnim.Play("CameraLanding");
            inAir = false;
        }

        jumpInnert = Vector3.Lerp(jumpInnert, Vector3.zero, 5f * Time.deltaTime);

        move.y = 0;
        move += jumpInnert;
        move *= speed;
        move.y = verticalvelocity;
        controller.Move(move * Time.deltaTime);
        //controller.Move(move * speed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.normal.y < 0.1f && hit.gameObject.layer != LayerMask.NameToLayer("Border"))
        {
            if (Input.GetButtonDown("Jump") && inAir)
            {
                //Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
                jumpInnert = hit.normal * 4f;
                verticalvelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }
    }
}
