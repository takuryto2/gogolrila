/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class courbeprojo : MonoBehaviour
{
    [range(-10, 10)] public float Windforce;

    [range(1, 20)] public float Gravity = 9.81f;

    public GameObject SpeedGizmo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v =SpeedGizmo.transform.position - transform.position;
        Vector3 pCur = transform.position;
        for (int i = 0;i < 1000;i++) 
        {
            if (pCur.y < 0.0f)
                break;
            v += (Windforce * Vector3.right+Gravity*Vector3.down)*Time.fixedDeltaTime;
            Vector3 pNext = pCur + v * Time.fixedDeltaTime;

            Vector3.Reflect(pNext,pCur);

            Debug.drawLine(pCur, pNext);

            pCur = pNext;
        }
    }
}*/