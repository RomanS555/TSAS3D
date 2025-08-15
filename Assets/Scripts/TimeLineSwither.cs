using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimeLineSwither : MonoBehaviour
{
    PlayableDirector playableDirector;
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }
    public void SwitchTimeLine(TimelineAsset clip)
    {
        playableDirector.Play(clip);
    }
}
