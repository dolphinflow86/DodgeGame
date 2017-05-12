using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public bool loop = false;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume = 1;

    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        if (source == null)
            return;
        source.volume = volume;
        source.loop = loop;
        source.Play();
    }

    public void Stop()
    {
        if (source == null)
            return;
        source.Stop();
    }
}

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("You have 2 AudioManagers in the scene!!");
        }
    }

    private void Start()
    {
        for (int i=0; i < sounds.Length; i++)
        {
            GameObject soundObject = new GameObject("Sound_" + i + "_" + sounds[i].name);
            soundObject.transform.parent = (this.transform);
            sounds[i].SetSource(soundObject.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                sounds[i].Play();
                return;
            }

        }
            Debug.LogWarning("Nothing to play!!");
    }

    public void Stop()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Stop();
        }
    }

}
