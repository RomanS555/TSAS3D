using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public static Action<bool> callInventory;
    [SerializeField] GameObject inventoryTr;
    CurrentWeapon cw;
    void Start()
    {
        cw = GetComponent<CurrentWeapon>();
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cw.currentItem = ((cw.currentItem + ((Input.GetAxis("Mouse ScrollWheel") > 0) ? 1 : -1)) + Values.itemBar.Length * 2) % Values.itemBar.Length;
            cw.UpdateHotbar();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {

            inventoryTr.SetActive(!inventoryTr.activeSelf);
            if (inventoryTr.activeSelf) Inventory.UpdateInventory?.Invoke();
            callInventory?.Invoke(inventoryTr.activeSelf);

        }
    }
}
