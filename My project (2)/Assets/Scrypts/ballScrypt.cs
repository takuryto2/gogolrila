using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScrypt : MonoBehaviour
{
    public void ball2(Vector3 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction;
    }
}
