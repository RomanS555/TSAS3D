using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerTriggerCollision : MonoBehaviour
{
    Camera cam;
    [SerializeField] Text texMessage;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 12f, 1 << 6))
        {

            if (hit.transform.TryGetComponent<DetectPlayerTrigger>(out DetectPlayerTrigger DpT))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DetectPlayerTrigger[] DpTs = hit.transform.GetComponents<DetectPlayerTrigger>();
                    foreach (DetectPlayerTrigger dpt in DpTs)
                    {
                        if(dpt.isActiveAndEnabled)
                        dpt.ActivateTrigger();
                    }  
                }


            }
            if (hit.transform.TryGetComponent<MouseLookMessage>(out MouseLookMessage mlm))
                {
                    texMessage.gameObject.SetActive(true);
                    texMessage.text = mlm.message;
                }else
        texMessage.gameObject.SetActive(false);
        }else
        texMessage.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        DetectPlayerTrigger cpt;
        if (other.gameObject.TryGetComponent<DetectPlayerTrigger>(out cpt))
        {
            cpt.ActivateTrigger();
        }
    }
}
