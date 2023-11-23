using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrypt : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpStrength;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D> ();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            myRigidbody.velocity = Vector2.up * jumpStength;
        }
    }
}
