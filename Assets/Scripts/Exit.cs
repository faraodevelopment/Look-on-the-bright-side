using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField]Animator animator;
    [SerializeField]Cinemachine.CinemachineVirtualCamera cam;
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        cam.Priority = 11;
        animator.SetTrigger("exit");
        EventControl.OnWin?.Invoke();
        GetComponent<AudioSource>().Play();
        StartCoroutine(Response());
    }
    IEnumerator Response()
    {
        yield return new WaitForSeconds(2f);
        if (!source.isPlaying)
        {
            source.clip = Resources.Load<AudioClip>("audio/whoareyou");
            source.Play();
            StartCoroutine(WaitforTalkToEnd());
            
        }
        
    }
    IEnumerator WaitforTalkToEnd()
    {
        yield return new WaitForSeconds(source.clip.length);
        SceneManager.LoadSceneAsync("End");
    }
}
