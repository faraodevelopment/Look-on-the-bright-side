using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogPlay : MonoBehaviour
{
    [SerializeField]
    List<string> text = new List<string>();
    [SerializeField]
    List<AudioClip> clips = new List<AudioClip>();
    TMP_Text uiText;
    [SerializeField] GameObject tPanel;
    [SerializeField] float talkSpeed = 1f;

    private void OnEnable()
    {
        EventControl.OnDialog += UpdateDialog;

    }
    private void OnDisable()
    {
        EventControl.OnDialog -= UpdateDialog;
    }
    private void UpdateDialog()
    {
        tPanel.SetActive(true);
        if(text.Count > 0)
        {
            uiText.SetText(text[0]);
            text.RemoveAt(0);
            if(clips.Count > 0)
            {
                EventControl.OnVoice?.Invoke(clips[0]);
                clips.RemoveAt(0);
            }
            
        }
        else
        {
            tPanel.SetActive(false);
            uiText.SetText("");
            EventControl.OnDialogComplete?.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        uiText = GetComponent<TMP_Text>();
        if (uiText.text == "")
        {
            tPanel.SetActive(false);
        }
    }

  
}
