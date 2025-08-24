using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Inv", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public enum InteractType { none, shooting, punch, grenade };
    public string ItemName;
    [TextArea(3, 10)]
    public string ItemDescritpion;
    public Sprite ItemIcon, ItemInHand;
    public InteractType interact = InteractType.none;
    public bool longPressInteraction = false;
    public float interactCoolDown = 0.2f;



    

   
}
