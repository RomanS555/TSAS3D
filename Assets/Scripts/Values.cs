
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Values : MonoBehaviour
{
    
    public static float SnickersV = 100;
    public static float HP = 100;
    [SerializeField] float speedsubS = 0.2f;
    [SerializeField] AudioClip getSnickers;
    [SerializeField] Slider slider, HPbar;
    public static List<int> InventoryS = new List<int>();
    public static int[] itemBar = {-1,0,-1};
    public static float maxHP = 100;
    public const float maxSnickers = 100;

    public void Add2Hp(float ahp)
    {
        HP += ahp;
    }
    public void Add2Snkrs(float asnkrs)
    {
        SnickersV += asnkrs;
    }

    public void AddItemToInventory(int item)
    {
        Debug.Log($"Добавлен предмет {item}");
        InventoryS.Add(item);
    }
    public void RemoveItemInventoryAtIndex(int index)
    {
        InventoryS.RemoveAt(index);
    }


    private void Start()
    {

    }


    private void Update() {
        slider.value = SnickersV;
        HPbar.value = HP;
        HPbar.maxValue = maxHP;
        SnickersV -= Time.deltaTime*speedsubS;
        
    }
}
