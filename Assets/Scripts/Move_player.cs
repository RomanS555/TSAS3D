using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(playerTriggerCollision))]
public class Move_player : MonoBehaviour
{
    [SerializeField] private float
        moveSpeed = 600,
        airSpeed = 0.4f,
        jumpStrengh = 10,
        downStrengh = 4,
        waterSpeed = 0.8f;
    [SerializeField] bool isGround, isWall,isWater;
    [SerializeField] GameObject WaterHUD;
    [SerializeField] private Vector3 velocity;
    [SerializeField]Collider wallCheck;
    bool isMenu;
    float normalJump = 1, axeX, axeZ, jumpCooldown = 1, _jumpCD;
    Camera cam;
    [SerializeField]LayerMask Water;
    MouseLook ml;
    private Rigidbody rb;
    void Start()
    {
        PlayerInputs.callInventory += stopMove;
        ml = GetComponent<MouseLook>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        
    }
    void stopMove(bool b)
    {
        isMenu = b;
    }

    void Update()
    {
        
        axeX = Input.GetAxis("Horizontal")* (!isMenu ? 1f : 0f);
        axeZ = Input.GetAxis("Vertical")* (!isMenu ? 1f : 0f);
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
        
        Vector3 moveVector = (ml.rotPoint.forward * axeZ + ml.rotPoint.right * axeX) * Time.deltaTime * moveSpeed;
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
        if (isGround) rb.velocity = moveVector* normalGround + Vector3.up * rb.velocity.y;
        else if (!isWater) rb.velocity = moveVector* airSpeed + Vector3.up * rb.velocity.y;
        float axisY = (Input.GetButton("Jump") ? 1f : 0f)*(jumpStrengh / 2f) - (Input.GetButton("Sit") ? 1f : 0f)*(downStrengh / 2f);
        if (isWater)
        {
            rb.velocity = moveVector * waterSpeed + Vector3.up * (rb.velocity.y + 10 * Time.deltaTime);
            if (axisY != 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y + Time.deltaTime*axisY,-8f, 8f), rb.velocity.z);
            }
        }
        
    }
    
    private void OnCollisionStay(Collision other) {
        foreach (ContactPoint contactPoint in other.contacts)
        {
            if (contactPoint.thisCollider == wallCheck)
            {
                 if (!isGround)
                    {
                        axeX = 0;
                        axeZ = 0;
                    }
            }
        }
           
        
    }

    
   
}
