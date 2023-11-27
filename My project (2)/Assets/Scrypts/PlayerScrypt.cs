using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerscrypt : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("mouvment")]
    public float moveSpeed = 5.0f;
    public int dir = 1;
    float horizontalMovment;


    [Header("jump")]
    public float jumpPower = 3.0f;
    float verticalMovment;

    [Header("groundcheck")]
    public Transform groundcheckpos;
    public Vector2 groundchecksize = new Vector2(0.5f, 0.05f);
    public LayerMask groundlayer;

    [Header("shoot")]
    [SerializeField] GameObject ball;
    public float launchstr = 10f;
    public float angle = 90;
    private int dirangle = 0;
    private bool powering = false;


    void Start()
    {
        
    }

    void Update()
    {
        rb.velocity = new Vector2(horizontalMovment * moveSpeed, rb.velocity.y);
        ChangeAngle();
        ResetAngle();
        forceup();
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovment = context.ReadValue<Vector2>().x;
        if (Mathf.Sign(context.ReadValue<Vector2>().x) != dir && (int)context.ReadValue<Vector2>().x != 0)
        {
            angle = -1;
            dir = -1;
            dirangle *= -1;
        }
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
        if (context.canceled)
        {
            float x = Mathf.Cos((angle - 90) * dir * Mathf.PI / 180);
            float y = Mathf.Sin((angle - 90) * Mathf.PI / 180);
            Vector3 direction = new Vector3(x * launchstr, y * launchstr, 0);
            Vector3 spawn = new Vector3(transform.position.x + x, transform.position.y + y, 0);
            GameObject balls = Instantiate(ball, spawn, transform.rotation);
            balls.GetComponent<Ball_Movement>().SetBullet((Vector3)direction);
            powering = false;
            launchstr = 0;
        }
    }
    private void forceup()
    {
        if (powering)
        {
            launchstr += 0.1f;
        }
        if (launchstr > 20)
        {
            launchstr = 20;
        }
    }

    private void ChangeAngle()
    {
        switch (dirangle)
        {
            case 1:
                angle += dir;
                break;
            case -1:
                angle -= dir;
                break;
            default:
                break;
        }
    }

    private void ResetAngle()
    {
        switch (dir)
        {
            case 1:
                if (angle < 45)
                {
                    angle = 45;
                }
                else if (angle > 135)
                {
                    angle = 135;
                }
                break;
            case -1:
                if (angle > -45)
                {
                    angle = -45;
                }
                else if (angle < -135)
                {
                    angle = -135;
                }
                break;
            default:
                print("directional error");
                break;
        }
    }

    public void aim(InputAction.CallbackContext Context)
    {
        if (Context.started)
        {
            dirangle += (int)(Context.ReadValue<float>()) * -dir;
        }
        if (Context.canceled)
        {
            dirangle = 0;
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
