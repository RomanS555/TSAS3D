using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamagePlayerTrigger : EventParent
{
    [SerializeField] List<UnityEvent<CurrentWeapon>> TriggerEvent;
    [SerializeField] int currentList;
    [SerializeField] InventoryItem requireItem;
    [SerializeField] float knockbackForce = 70f;
    Rigidbody rb;

    void Start()
    {
        TryGetComponent(out rb);
    }

    public void ActivateTrigger(CurrentWeapon pl)
    {
        
        
        if (!requireItem || !pl || requireItem == pl?.itemInhotbar)
            TriggerEvent[currentList]?.Invoke(pl);

    }
    public void SwitchEventList(int n)
    {
        currentList = n;
    }
    
    
    public void Knockback(CurrentWeapon pl)
    {
        MouseLook ml;
        pl.TryGetComponent(out ml);
        if (rb)
            rb.velocity += ml.rotPoint.transform.forward * (knockbackForce + pl.itemInhotbar.KnockBack);
    }
}
