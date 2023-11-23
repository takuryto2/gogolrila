using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Update is called once per frame
    public float speed = 5f;
    public float gravity = 7f;

    void Update()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");

        Vector2 deplacement = new Vector2(deplacementHorizontal, deplacementVertical);

        deplacement.Normalize();

        GetComponent<Rigidbody2D>().velocity = new Vector2(deplacement.x * speed, deplacement.y * speed);
    }
}