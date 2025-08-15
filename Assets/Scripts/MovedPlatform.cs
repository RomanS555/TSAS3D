using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedPlatform : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Vector3 endPos;
    [SerializeField] Quaternion endRot;
    public void MovePlatform(Transform tr)
    {
        endPos = tr.position;
        endRot = tr.rotation;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, endRot, Time.deltaTime * speed);
        
    }
}
