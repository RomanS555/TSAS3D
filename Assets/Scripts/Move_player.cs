using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_player : MonoBehaviour
{
    [SerializeField] private float gravitation;
    [SerializeField] private float decceleration;
    [SerializeField] private float moveSpeed; 
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpStrengh;
    [SerializeField] bool isGround;
    [ SerializeField] GameObject WaterHUD;
    [SerializeField] private Vector3 velocity;
    Collider grCheck;
    bool isWater;
    Camera cam;
    [SerializeField]LayerMask Water;
    private Rigidbody rb;
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        grCheck = GetComponent<BoxCollider>();
    }

 
    void Update()
    {
       
        
        if(Input.GetKeyDown(KeyCode.Space) && isGround){
            rb.velocity += transform.up * jumpStrengh;
        }
       
        
    }
    private void FixedUpdate() {
        isWater = Physics.CheckSphere(cam.transform.position,1,Water);
        WaterHUD.SetActive(isWater);
        float axeX = Input.GetAxis("Horizontal");
        float axeZ = Input.GetAxis("Vertical");
        if(!isGround){
            if(!isWater){
            rb.velocity += Vector3.down *Time.deltaTime *gravitation/2.1f;
            }else rb.velocity += Vector3.down * gravitation * Time.deltaTime;
        }
        rb.velocity = (transform.forward * axeZ + transform.right* axeX ) * Time.deltaTime * moveSpeed+ Vector3.up * rb.velocity.y;
    }
    private void OnTriggerStay(Collider other) {
        isGround = true;
       
    }
    private void OnTriggerExit(Collider other) {
        isGround = false;
    }
    private void OnCollisionEnter(Collision other) {
         if(other.gameObject.layer == Water){
            rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y/2.1f,rb.velocity.z);
        }
    }

    
   
}
