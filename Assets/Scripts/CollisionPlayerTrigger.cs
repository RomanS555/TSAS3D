using System;
using UnityEngine;


public class CollisionPlayerTrigger : MonoBehaviour
{
    [SerializeField] Action TriggerEvent;

    public void ActivateTrigger()
    {
        TriggerEvent?.Invoke();
    }
}
