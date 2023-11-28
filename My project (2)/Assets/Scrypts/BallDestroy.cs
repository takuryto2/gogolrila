using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject,5);
    }
}
