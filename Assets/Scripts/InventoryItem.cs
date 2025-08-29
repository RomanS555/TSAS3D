using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;


[CreateAssetMenu(fileName = "Inv", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public enum InteractType { none, shooting, punch, grenade };
    public string ItemName;
    [TextArea(3, 10)]
    public string ItemDescritpion;
    public Sprite ItemIcon, ItemInHand, particleOnAction;
    public InteractType interact = InteractType.none;
    public bool longPressInteraction = false;
    public float interactCoolDown = 0.2f;
    public AudioClip soundOnInteract;
    [ShowIf("isWeapon")]
    [Min(0)]
    public float DamageWeapon, KnockBack;
    bool isWeapon => interact == InteractType.punch || interact == InteractType.shooting;

    

   
}
