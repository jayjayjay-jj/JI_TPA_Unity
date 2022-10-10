using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private float speed = -0.01f;

    private float currRotation;
    
    // Update is called once per frame
    void Update()
    {
        currRotation += speed;
        transform.rotation = Quaternion.Euler(0, currRotation, 0);
    }
}
