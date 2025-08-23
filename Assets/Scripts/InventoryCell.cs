using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{


    public InventoryItem inventoryItem;
    public int ID;
    
    Inventory inv;
    Image icon;
    Button button;
    void Start()
    {
        icon = transform.GetChild(0).GetComponent<Image>();
        button = GetComponent<Button>();
        inv = transform.parent.GetComponent<Inventory>();
        icon.sprite = inventoryItem.ItemIcon;
        button.onClick.AddListener(setCurrentCell);
    }
    void setCurrentCell() {
        inv.setCurrentCell(this);
    }
    
    


}
