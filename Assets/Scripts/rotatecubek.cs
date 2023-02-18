using UnityEngine;

public class rotatecubek : MonoBehaviour
{
    
    public float speed;
    const float PI = 3.1415f;
    Rigidbody rb;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        Debug.Log(rotation.y);
        rb.velocity = new Vector3(Mathf.Sin(rotation.y * Mathf.Deg2Rad) * speed, 0 , Mathf.Cos(rotation.y * Mathf.Deg2Rad)* speed);
    }
}
