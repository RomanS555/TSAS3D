using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Inv", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public string ItemName;
    [TextArea(3,10)]
    public string ItemDescritpion;
    public Sprite ItemIcon, ItemInHand;
    

   
}
