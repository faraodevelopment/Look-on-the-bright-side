using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOver : MonoBehaviour
{
    private static VoiceOver instance;
    AudioSource audioSource;
    AudioClip running, next;
    private void OnEnable()
    {
        EventControl.OnVoice += PlayVoice;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlayVoice(AudioClip audioClip)
    {
        next = audioClip;
        if ((audioSource.isPlaying && audioSource.time < running.length - 3)||!audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.clip = next;
            audioSource.Play();
            running = next; next = null;
        }
        else
        {
            Debug.Log("invoke delay");
            Invoke("PlayLater", 3);
        }
        
    }
    void PlayLater()
    {
        audioSource.Stop();
        audioSource.clip = next;
        audioSource.Play();
        running = next;next = null;
    }
}
