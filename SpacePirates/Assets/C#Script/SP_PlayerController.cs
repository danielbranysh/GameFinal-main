﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SP_PlayerController : MonoBehaviour
{
    //Compnents
    Rigidbody2D myRB;
    Transform myAvatar;
    Animator myAnim;
    //Player movement 
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;

    private void OnEnable()
    {
        WASD.Enable();
    }

    private void OnDisable()
    {
        WASD.Disable();
    }

    //Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAvatar = transform.GetChild(0);

        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        movementInput = WASD.ReadValue<Vector2>();
        if (movementInput.x != 0)
        {
            myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
        }

        myAnim.SetFloat("Speed", movementInput.magnitude);
    }
    private void FixedUpdate()
    {
        myRB.velocity = movementInput * movementSpeed;
    }
}