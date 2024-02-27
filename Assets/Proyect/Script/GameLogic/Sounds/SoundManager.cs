using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public enum Sound
    {
        GameOver,//Asigned
        Win,//Asigned
        Shot,//Asigned
        Drop,//Assigned
        Scale,//Assigned
        Jump,//Assigned
        Bounce,//Assigned
        Lazy,//Assigned
        Coins//Assigned
    }

    private static GameObject soundManagerGameObject;
    private static AudioSource audioSource;
    public AudioClip[] soundAudioClipsArray;
    private void Awake()//Singleton
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Instance");
        }

        Instance = this;
        CreateSoundManagerGameObject();
    }

    public static void CreateSoundManagerGameObject()
    {
        if (soundManagerGameObject == null)
        {
            soundManagerGameObject = new GameObject("Sound Manager");
            audioSource = soundManagerGameObject.AddComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("Sound Manager already exists");
        }
    }

    public void PlaySound(Sound sound)
    {
        // Obtain the AudioClip associated with the Sound
        AudioClip audioClip = GetAudioClipFromSound(sound);

        // Check if the AudioClip was found
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogError("AudioClip for Sound " + sound + " not found");
        }
    }

    public AudioClip GetAudioClipFromSound(Sound sound)
    {
        foreach (AudioClip soundAudioClip in soundAudioClipsArray)
        {
            // Compare the name of the AudioClip with the name of the Sound
            if (soundAudioClip.name == sound.ToString())
            {
                return soundAudioClip;
            }
        }
        return null;
    }
}
