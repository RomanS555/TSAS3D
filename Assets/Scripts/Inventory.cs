using System;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Action UpdateInventory;

    [SerializeField] GameObject prefabInventoryCell;
    [SerializeField] Text nameItem, descriptionItem;
    [SerializeField]ItemIndex itemIndex;
    InventoryItem[] itemAtIndex;
    [SerializeField] ActiveCell[] itemBar;
    InventoryCell currentCell;
    void Awake()
    {
        itemAtIndex = itemIndex.itemAtIndex;
        UpdateInventory += UpdateItems;
        
    }
    void Start()
    {
        
    }
    void Update()
    {
        descriptionItem.gameObject.SetActive(currentCell);
        if (Input.GetMouseButton(1))
        {
            currentCell = null;
        }
        if (currentCell)
        {
            nameItem.text = currentCell.inventoryItem.ItemName;
            descriptionItem.text = currentCell.inventoryItem.ItemDescritpion;
        }
        else
        {
            nameItem.text = "";
            descriptionItem.text = "";
        }
    }
    void UpdateItems()
    {
        for (int c = 0; c < transform.childCount; c++)
        {
            Destroy(transform.GetChild(c).gameObject);
        }
        int _id = 0;
        foreach (int item in Values.InventoryS)
        {
            GameObject cell = Instantiate(prefabInventoryCell, transform);
            if (cell.TryGetComponent<InventoryCell>(out InventoryCell invC))
            {
                invC.inventoryItem = itemAtIndex[item];
                invC.ID = _id;
                _id++;
            }

        }

        foreach (ActiveCell ac in itemBar)
        {
            ac.inventoryItem = null;
            if (Values.itemBar[ac.ID] >= 0)
            {
                ac.inventoryItem = itemAtIndex[Values.itemBar[ac.ID]];
            }
        }
        
    }


    public void setCurrentCell(InventoryCell iCell)
    {
        currentCell = iCell;
    }
    public void SwitchItems(ActiveCell ac)
    {
        if (Values.itemBar[ac.ID] > -1)
        {
            Values.InventoryS.Add(Values.itemBar[ac.ID]);
            Values.itemBar[ac.ID] = -1;
        }
        if (currentCell)
        {
            Values.itemBar[ac.ID] = FindItemIndex(currentCell.inventoryItem, itemAtIndex);
            Values.InventoryS.RemoveAt(currentCell.ID);
        }
        UpdateItems();
        ac.cw.UpdateHotbar();
    }
    public static int FindItemIndex(InventoryItem i, InventoryItem[] ii) {
        for (int j = 0; j < ii.Length; j++)
        {
            if (ii[j] == i)
            {
                return j;
            }
        }
        return 0;
    }
}
