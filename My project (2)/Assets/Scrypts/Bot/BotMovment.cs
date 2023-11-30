using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovment : MonoBehaviour
{
    [Header("groundcheck")]
    public Transform botleftwallcheckpos;
    public Vector2 botleftwallchecksize = new Vector2(0.5f, 0.05f);
    public LayerMask groundlayer;
    private bool faceLeftWall()
    {
        if (Physics2D.OverlapBox(botleftwallcheckpos.position, botleftwallchecksize, 0, groundlayer))
        {
            return true;
        }

        return false;
    }

    //if ()

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(botleftwallcheckpos.position, botleftwallchecksize);
    }
}
