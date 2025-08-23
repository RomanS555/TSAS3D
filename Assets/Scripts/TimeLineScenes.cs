using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineScenes : MonoBehaviour
{
    public static Action stopTimeLineAction;
    PlayableDirector pd;
    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        stopTimeLineAction += stopTimeLine;
        
    }


    void stopTimeLine()
    {
        pd.Stop();
    }
}
