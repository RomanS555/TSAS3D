using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveCell : MonoBehaviour
{
    public InventoryItem inventoryItem;
    public int ID;
    public CurrentWeapon cw;
    [SerializeField] Image icon;
    [SerializeField] GameObject selectedMark;

    void Update()
    {
        
        selectedMark.SetActive(ID == cw.currentItem);
        if (inventoryItem)
        {
            
            icon.sprite = inventoryItem.ItemIcon;
        }
        else icon.sprite = null;
    }
}
