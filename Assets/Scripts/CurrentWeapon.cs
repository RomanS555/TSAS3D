using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeapon : MonoBehaviour
{

    
    [SerializeField] Image imageHand;
    [SerializeField] ItemIndex itemIndex;
    InventoryItem itemInhotbar;
    public int currentItem = 0;
    void Start()
    {
        UpdateHotbar();

    }

    // Update is called once per frame
    void Update()
    {
        imageHand.gameObject.SetActive(itemInhotbar);
        if (itemInhotbar)
        {
            imageHand.sprite = itemInhotbar.ItemInHand;
        }

    }
    public void UpdateHotbar()
    {

        for (int i = 0; i < Values.itemBar.Length; i++)
        {
            if (i == currentItem ) {
                if (Values.itemBar[i] >= 0)
                {
                    itemInhotbar = itemIndex.itemAtIndex[Values.itemBar[i]];
                }else itemInhotbar = null;
            }
                
            
        }
    }
}
