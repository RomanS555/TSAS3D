using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamagePlayerTrigger : MonoBehaviour
{
    [SerializeField] List<UnityEvent> TriggerEvent;
    [SerializeField] int currentList;
    [SerializeField] InventoryItem requireItem;

    void Start()
    {

    }

    public void ActivateTrigger(CurrentWeapon pl)
    {
        if(!requireItem || !pl || requireItem == pl?.itemInhotbar)
        TriggerEvent[currentList]?.Invoke();
        
    }
    public void SwitchEventList(int n)
    {
        currentList = n;
    }
    public void DestroyObj(Object obj)
    {
        Destroy(obj);
    }
}
