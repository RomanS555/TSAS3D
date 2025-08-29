using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnAnimationEnd : EventParent
{
    [SerializeField] UnityEvent unityEvent;
    [SerializeField]AnimationClip clip;
    Animator an;
    
    void Start()
    {
        TryGetComponent(out an);
        an.Play(clip.name, -1, 0);
        StartCoroutine(eventOnTimer(clip.length));
    }
    
    IEnumerator eventOnTimer(float time) {

        yield return new WaitForSeconds(time);
        unityEvent?.Invoke();
    }
    
}
