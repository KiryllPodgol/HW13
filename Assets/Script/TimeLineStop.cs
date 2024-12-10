using UnityEngine;
using UnityEngine.Playables;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TimelineEndHandler : MonoBehaviour
{
    public PlayableDirector director; 

    void Start()
    {
        if (director != null)
        {
            director.stopped += OnTimelineStopped;
        }
    }

    void OnTimelineStopped(PlayableDirector pd)
    {
        if (pd == director)
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false; 
            #else
            Application.Quit();
            #endif
        }
    }

    void OnDestroy()
    {
        if (director != null)
        {
            director.stopped -= OnTimelineStopped;
        }
    }
}
