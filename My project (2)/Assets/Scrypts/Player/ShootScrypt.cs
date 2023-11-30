using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScrypt : MonoBehaviour
{
    [Header("aim")]
    private Vector2 mousePos;
    [SerializeField] private GameObject ball;
    [SerializeField] private InputActionReference shot, mousePos2;
    Transform player;

    // cooldown values
    private float nextShot = 0.20f;
    [SerializeField] private float fireDelay = 0.6f;

    void Start()
    {
        player = transform;
    }

    public void fire(InputAction.CallbackContext ctx)
    {
        if (ctx.canceled && Time.time > nextShot)
        {
            GameObject newball = Instantiate(ball, player.position, Quaternion.identity);
            newball.TryGetComponent<Rigidbody2D>(out Rigidbody2D ballbody);
            ballbody.velocity += mousePos - (Vector2)player.position;
            nextShot = Time.time + fireDelay;
        }
    }

    public void gatherDirection(InputAction.CallbackContext ctx)
    {
        mousePos = ctx.ReadValue<Vector2>();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

}