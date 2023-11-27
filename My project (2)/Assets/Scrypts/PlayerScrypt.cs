using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerscrypt : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("mouvment")]
    public float moveSpeed = 5.0f;
    float horizontalMovment;

    [Header("jump")]
    public float jumpPower = 3.0f;
    float verticalMovment;

    [Header("groundcheck")]
    public Transform groundcheckpos;
    public Vector2 groundchecksize = new Vector2(0.5f, 0.05f);
    public LayerMask groundlayer;

    [Header("prefab")]
    [SerializeField] GameObject ball;


    void Start()
    {
        
    }

    void Update()
    {
        rb.velocity = new Vector2(horizontalMovment * moveSpeed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovment = context.ReadValue<Vector2>().x;
    }

    public void jump(InputAction.CallbackContext context) 
    {
        //full jump
        if (isgrounded())
        {
            if (context.performed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }

            //short jump
            else if (context.canceled)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower - 3);
            }
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject balls = Instantiate(ball,transform.position , transform.rotation );
        }
    }

    private bool isgrounded()
    {
        if (Physics2D.OverlapBox(groundcheckpos.position, groundchecksize, 0, groundlayer))
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundcheckpos.position, groundchecksize);
    }
}