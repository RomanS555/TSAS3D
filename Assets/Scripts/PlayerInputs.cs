using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputs : MonoBehaviour
{
    public static Action<bool> callInventory;
    [SerializeField] GameObject inventoryTr, prefabBulletHole;
    [SerializeField] ItemIndex itemIndex;
    AudioSource audioSource;

    ItemAnimations itemAnimations;
    float interactCoolDown = 0f;
    CurrentWeapon cw;
    Camera cam;
    bool inInventory = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
        itemAnimations = GetComponent<ItemAnimations>();
        cw = GetComponent<CurrentWeapon>();
    }
    void Update()
    {
        inInventory = inventoryTr.activeSelf;
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
        if (cw.itemInhotbar && !inInventory)
        {
            InventoryItem _item = cw.itemInhotbar;

            if (interactCoolDown < _item.interactCoolDown)
            {
                interactCoolDown += Time.deltaTime;
            }
            else
            {
                if (_item.longPressInteraction)
                {
                    if (Input.GetMouseButton(0)) interactItem(_item);
                }
                else
                {
                    if (Input.GetMouseButtonDown(0)) interactItem(_item);
                }
            }
        }
    }
    void interactItem(InventoryItem _item)
    {
        interactCoolDown = 0;
        if (_item.soundOnInteract)
        {
            audioSource.PlayOneShot(_item.soundOnInteract);
        }
        switch (_item.interact)
        {
            case InventoryItem.InteractType.shooting:
                Damage(500f);
                itemAnimations.Fire();
                break;
            case InventoryItem.InteractType.punch:
                Damage(6f);
                itemAnimations.Punch();
                break;
            case InventoryItem.InteractType.grenade:
                Debug.Log("<F<F{!}>");
                break;
        }
    }
    void Damage(float distance)
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance, ~((1 << 7) + (1 <<2))))
        {
            Instantiate(prefabBulletHole, hit.point, cam.transform.rotation);
            if (hit.transform.TryGetComponent<DamagePlayerTrigger>(out var DpT))
            {
                DpT.ActivateTrigger(cw);
            }
            
        }
    }
    
    
}
