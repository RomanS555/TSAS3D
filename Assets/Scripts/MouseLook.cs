using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivity;
    [SerializeField] float maxAngle = 90f;
    public Transform rotPoint;
    float rotY = 0;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rotPoint.Rotate(0,Input.GetAxis("Mouse X")*sensitivity,0);
        
        rotY += Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY,-maxAngle,maxAngle);
        cam.transform.localEulerAngles = new Vector3(-rotY,0,0);
    }
}
