using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    bool dialogComplete;
    [SerializeField] float talkSpeed = 1f;
    int numJokes;

    private void OnEnable()
    {
        EventControl.OnDialogComplete += ContinueGame;
        EventControl.OnExitMessage += WinCondition;
        EventControl.OnGameOver += LoseCondition;
        EventControl.OnJoke += CountJokes;

    }

    private void CountJokes(float intensity)
    {
        numJokes++;
        if(numJokes % 3==0) { EventControl.OnSafety?.Invoke(); }
    }

    private void LoseCondition()
    {
        SceneManager.LoadSceneAsync("GameOver");

    }

    private void WinCondition()
    {
        //Time.timeScale = 0f;
    }

    private void ContinueGame()
    {
        dialogComplete = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0f;
        InvokeRepeating("ChangeDialog", talkSpeed, talkSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeDialog()
    {
        if (!dialogComplete)
        {
            EventControl.OnDialog?.Invoke();
        }
       
    }
}
