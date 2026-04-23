using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{   
    [SerializeField] private Sound[] soundEffects;

    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(String name)
    {
        Sound sound = Array.Find(instance.soundEffects, x => x.name.Equals(name));
        if (sound != null) instance.audioSource.PlayOneShot(sound.clip);
    }
    
}
