using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTriggerCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        DetectPlayerTrigger cpt;
        if (other.gameObject.TryGetComponent<DetectPlayerTrigger>(out cpt))
        {
            cpt.ActivateTrigger();
        }
    }
}
