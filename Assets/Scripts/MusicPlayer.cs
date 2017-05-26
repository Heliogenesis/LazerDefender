using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MusicPlayer : MonoBehaviour
{
    public List<AudioClip> tracks;
    public List<string> trackNames;

    [SerializeField]
    private AudioSource source;
    static private MusicPlayer instance;


    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    protected virtual void Start()
    {
        PlayMusic("Start");
    }

    public void PlayMusic(string track)
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                int trackIndex = trackNames.FindIndex(trackString => trackString == track); //Converts the string to a System.Predicate<string>
                //GameObject nextTrack = instance.tracks[];
                instance.source.clip = tracks[trackIndex];
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }    
}