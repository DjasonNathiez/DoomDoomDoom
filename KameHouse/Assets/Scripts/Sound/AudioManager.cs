using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Singleton;
    
    private List<AudioSource> audioSources;
    private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
    public List<Sound> sounds;

    private void Awake()
    {
        audioSources = new List<AudioSource>();
        
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this);
        }
        
        foreach (Sound s in sounds)
        {
            clips.Add(s.soundName,s.clip);
        }
    }

    public void PlaySound(string soundName, bool randomPitch = false)
    {
        foreach (Sound sound in sounds)
        {
            if (soundName == sound.soundName)
            {
               
                    AudioSource s = gameObject.AddComponent<AudioSource>();
                    audioSources.Add(s);
                
                    s.clip = sound.clip;
                    s.volume = sound.volume;
                    s.pitch = randomPitch ? Random.Range(0f, 1f) : sound.pitch;
                    s.loop = sound.isLoop;
                    
                    s.Play();
                    
                    StartCoroutine(ClearingSound(s));

            }
        }
    }
    
    IEnumerator ClearingSound(AudioSource source)
    {
        yield return new WaitUntil(() => !source.isPlaying);
        Destroy(source);
    }
}

[Serializable] public class Sound
{
    public string soundName;
    public AudioClip clip;
    [Range(0,1)] public float volume = 1;
    [Range(0,1)] public float pitch;
    public bool isLoop;
}
