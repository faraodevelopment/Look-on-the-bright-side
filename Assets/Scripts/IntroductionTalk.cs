using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionTalk : MonoBehaviour
{
    [SerializeField] AudioClip captaintalk;
    [SerializeField] AudioClip good;
    [SerializeField] AudioClip bad;
    bool anger;
    AudioSource audioS;
    [SerializeField] GameObject answerPanel;
    // Start is called before the first frame update
    void Start()
    {
        answerPanel.SetActive(false);
        audioS = GetComponent<AudioSource>();
        audioS.clip = captaintalk;
        audioS.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (audioS.isPlaying) return;
        if(answerPanel != null&&answerPanel.activeSelf==false&&!anger) 
        { 
            answerPanel.SetActive(true);
        }
    }
    private void OnEnable()
    {
        EventControl.OnAgree += Affirm;
        EventControl.OnEvade += Evade;
        EventControl.OnAnger += Anger;
    }
    private void OnDisable()
    {
        EventControl.OnAgree -= Affirm;
        EventControl.OnEvade -= Evade;
        EventControl.OnAnger -= Anger;
    }
    void Affirm()
    {
        
        audioS.clip = good;
        audioS.Play();
    }
    void Evade()
    {
        audioS.clip = bad;  
        audioS.Play();
    }
    void Anger()
    {
        audioS.Stop();
        SceneManager.LoadSceneAsync("DOA");
    }
}
