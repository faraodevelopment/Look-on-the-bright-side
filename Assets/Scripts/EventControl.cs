using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventControl : MonoBehaviour
{
    public static EventControl Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static UnityAction OnDialog;
    public static UnityAction OnDialogComplete;
    public static UnityAction<float> OnJoke;
    public static UnityAction OnAgree;
    public static UnityAction OnEvade;
    public static UnityAction OnAnger;
    public static UnityAction OnExitMessage;
    public static UnityAction OnGameOver;
    public static UnityAction OnHands;
    public static UnityAction OnHandsOut;
    public static UnityAction OnSafety;
    public static UnityAction<float> OnHealth;
    public static UnityAction OnWin;
    public static UnityAction<AudioClip> OnVoice;
}
