using UnityEngine.Events;
using UnityEngine;


public class DetectPlayerTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent TriggerEvent;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(new Vector2(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2)), out hit)){
            
        }
    }
    public void ActivateTrigger()
    {
        TriggerEvent?.Invoke();
    }
}
