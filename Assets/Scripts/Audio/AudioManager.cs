using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
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
        source.volume = volume;
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    private void Awake()
    {
        instance = this;
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
                Debug.Log("sound played");
                return;
            }

        }
         
            Debug.Log("Nothing to play00");
        
    }

}
