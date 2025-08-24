using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnickersEater : MonoBehaviour
{
    [SerializeField] int snCount;
    [SerializeField] Transform snickersParent;
    [SerializeField] DetectPlayerTrigger dptIfAllSnickersEated,dptIfFirstSnickersEated;
    bool isFirst = true;
    
    public void EatSnickers()
    {
        if (isFirst)
        {
            dptIfFirstSnickersEated.ActivateTrigger(null);
            isFirst = false;
        }
        

    }
    void Update()
    {
        snCount = snickersParent.childCount;
        if (snickersParent.childCount==0)
        {
            dptIfAllSnickersEated.ActivateTrigger(null);
            Destroy(gameObject);
        }
    }
}
