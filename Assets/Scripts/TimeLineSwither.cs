using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimeLineSwither : MonoBehaviour
{
    
    public void SwitchTimeLine(PlayableDirector playableDirector)
    {
        TimeLineScenes.stopTimeLineAction?.Invoke();
        playableDirector.Play();
    }
}
