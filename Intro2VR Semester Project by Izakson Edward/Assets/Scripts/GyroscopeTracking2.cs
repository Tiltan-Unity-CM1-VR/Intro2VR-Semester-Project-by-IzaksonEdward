using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeTracking2 : MonoBehaviour
{

    Transform p;
#if UNITY_EDITOR
    void Awake()
    {
        if (!enabled)
            return;

       
        p = new GameObject("Gyro Root").transform;
        p.position = transform.position;
        p.SetParent(transform.parent, true);
        transform.SetParent(p);
        
       
    }

    private void Start()
    {
        Input.gyro.enabled = true;
    }
    void Update()
    {

        p.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);

    }

#endif
}