using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public enum Sound
    {
        Music,
        ButtonClick,
        GameOver,//falta
        Win,//falta
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
        // Obtener el AudioClip asociado al Sound
        AudioClip audioClip = GetAudioClipFromSound(sound);

        // Verificar si se encontr� el AudioClip
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
            // Comparar el nombre del AudioClip con el nombre del Sound
            if (soundAudioClip.name == sound.ToString())
            {
                return soundAudioClip;
            }
        }
        return null;
    }
}
