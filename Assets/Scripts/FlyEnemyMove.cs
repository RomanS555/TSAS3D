using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlyEnemyMove : MonoBehaviour
{
    [Header("movement values")]
    [SerializeField] float acceleration,maxHight, minHight,upSpeed;

    [Header("Visibility")]
    //[SerializeField] float visibilityMoveRadius = 30f;
    
    [SerializeField] float visibilityStopRadius = 10f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, minHight))
        {
            rb.velocity += -Physics.gravity* Time.deltaTime + Vector3.up * upSpeed * Time.deltaTime ;
        }
        if (!Physics.Raycast(transform.position, Vector3.down, maxHight))
        {
            rb.velocity += -Physics.gravity* Time.deltaTime;
        }
    }
    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            
            if(Physics.Raycast(transform.position, other.transform.position - transform.position, out  RaycastHit hit, 30f, (1 << 7) + (1 << 3)) && hit.transform == other.transform){
                Debug.Log(Vector3.Distance(other.transform.position, transform.position));
                if (Vector3.Distance(other.transform.position, transform.position) > visibilityStopRadius)
                {
                    
                    rb.velocity += (other.transform.position - transform.position).normalized * acceleration * Time.deltaTime;

                }
            }
            
        }
    }
}
