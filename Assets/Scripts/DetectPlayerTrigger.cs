using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;


public class DetectPlayerTrigger : MonoBehaviour
{
    [SerializeField] List<UnityEvent> TriggerEvent;
    int currentList;

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
}
