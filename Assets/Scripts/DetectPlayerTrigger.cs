using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;


public class DetectPlayerTrigger : MonoBehaviour
{
    [SerializeField] List<UnityEvent> TriggerEvent;
    [SerializeField] int currentList;

    void Start()
    {

    }

    public void ActivateTrigger()
    {
        TriggerEvent[currentList]?.Invoke();
    }
    public void SwitchEventList(int n)
    {
        currentList = n;
    }
    public void DestroyObj(Object obj)
    {
        Destroy(obj);
    }
}
