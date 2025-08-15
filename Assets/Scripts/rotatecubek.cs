using UnityEngine;

public class rotatecubek : MonoBehaviour
{
    
    public float speed;
    [SerializeField] private GameObject transformm;
    Rigidbody rb;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
    }
}
