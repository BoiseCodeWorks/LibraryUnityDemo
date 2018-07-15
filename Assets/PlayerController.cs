using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    Animator anim;
    CharacterController controller;
    Rigidbody rb;

    public float WalkSpeed = 5;
    public float RunSpeed = 10;
    public float JumpForce = 5;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
    }

    void GetPlayerInput()
    {
        var dir = Vector3.zero;
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        var walking = Input.GetKey(KeyCode.LeftShift);

        if (dir.magnitude > 1)
        {
            dir.Normalize();
        }

        controller.Move(
            dir * Time.deltaTime * 
            (walking ? WalkSpeed : RunSpeed) 
            );
    }

}
