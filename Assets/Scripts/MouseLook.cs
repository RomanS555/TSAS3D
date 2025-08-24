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
     bool isMenu;
    void Start()
    {
        PlayerInputs.callInventory += stopLook;
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void stopLook(bool b)
    {
        isMenu = b;
        if (b)
        {
            Cursor.lockState = CursorLockMode.None;
        }else Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        float axeX = Input.GetAxis("Mouse X")* (!isMenu ? 1f : 0f);
        float axeY = Input.GetAxis("Mouse Y")* (!isMenu ? 1f : 0f);
        rotPoint.Rotate(0,axeX*sensitivity,0);
        
        rotY -= axeY * sensitivity;
        rotY = Mathf.Clamp(rotY,-maxAngle,maxAngle);
        cam.transform.localEulerAngles = new Vector3(-rotY,0,0);
    }
}
