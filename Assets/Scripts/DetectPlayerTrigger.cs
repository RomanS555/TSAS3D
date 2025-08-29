using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;


public class DetectPlayerTrigger : EventParent
{
    [SerializeField] List<UnityEvent<CurrentWeapon>> TriggerEvent;
    [SerializeField] int currentList;
    [SerializeField] InventoryItem requireItem;

    void Start()
    {

    }

    public void ActivateTrigger(CurrentWeapon pl)
    {
        if(!requireItem || !pl || requireItem == pl?.itemInhotbar)
        TriggerEvent[currentList]?.Invoke(pl);
        
    }
    public void SwitchEventList(int n)
    {
        currentList = n;
    }
   
}
