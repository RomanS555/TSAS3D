using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInGround : MonoBehaviour
{
    [SerializeField] int itemId;
    public void AddItemInventory(CurrentWeapon pl)
    {
        Values val;
        pl.TryGetComponent(out val);
        val?.AddItemToInventory(itemId);
    }
}
