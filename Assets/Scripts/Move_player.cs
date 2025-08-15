using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_player : MonoBehaviour
{
    [SerializeField] private float
        moveSpeed = 600,
        airSpeed = 0.4f,
        jumpStrengh = 10,
        waterSpeed = 0.8f;
    [SerializeField] bool isGround;
    [SerializeField] GameObject WaterHUD;
    [SerializeField] private Vector3 velocity;
    Collider grCheck;
    [SerializeField]bool isWater;
    float normalJump = 1, axeX, axeZ, jumpCooldown = 1, _jumpCD;
    Camera cam;
    [SerializeField]LayerMask Water;
    MouseLook ml;
    private Rigidbody rb;
    void Start()
    {
        ml = GetComponent<MouseLook>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        grCheck = GetComponent<BoxCollider>();
    }


    void Update()
    {
        axeX = Input.GetAxis("Horizontal");
        axeZ = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && isGround && _jumpCD <= 0)
        {
            rb.velocity += transform.up * jumpStrengh * normalJump;
            _jumpCD = jumpCooldown;
        }
        if (_jumpCD > 0)
        {
            _jumpCD -= Time.deltaTime;
        }
       
        
    }
    private void FixedUpdate()
    {
        isWater = Physics.CheckSphere(cam.transform.position, 1, Water);
        if (WaterHUD) WaterHUD.SetActive(isWater);


        float normalGround = 1;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up * -1, out hit, 5f, 1 << 3))
        {
            Vector3 normalCos = new Vector3(Mathf.Sqrt(1 - hit.normal.x * hit.normal.x), Mathf.Sqrt(1 - hit.normal.y * hit.normal.y), Mathf.Sqrt(1 - hit.normal.z * hit.normal.z));
            normalGround = (Mathf.Pow(normalCos.x, 4) + Mathf.Pow(normalCos.z, 4)) / 2;
            normalJump = hit.normal.y;
            isGround = true;
        }
        else isGround = false;
        Debug.Log(normalGround);
        if (isGround) rb.velocity = (ml.rotPoint.forward * axeZ + ml.rotPoint.right * axeX) * normalGround * Time.deltaTime * moveSpeed + Vector3.up * rb.velocity.y;
        else if (!isWater) rb.velocity = (ml.rotPoint.forward * axeZ + ml.rotPoint.right * axeX) * airSpeed * Time.deltaTime * moveSpeed + Vector3.up * rb.velocity.y;
        else
        {
            rb.velocity = (ml.rotPoint.forward * axeZ + ml.rotPoint.right * axeX) * waterSpeed * Time.deltaTime * moveSpeed + Vector3.up * (rb.velocity.y + 8 * Time.deltaTime);
            if (Input.GetButton("Jump"))
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity +Vector3.up * jumpStrengh/2 * Time.deltaTime,8f);
            }
        }
        
    }
    
    private void OnCollisionEnter(Collision other) {
         
    }

    
   
}
