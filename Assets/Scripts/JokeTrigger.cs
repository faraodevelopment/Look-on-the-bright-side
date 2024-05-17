using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeTrigger : MonoBehaviour
{

    [SerializeField]
    float funnyLevel = 4f;

    [SerializeField]
    AudioClip whistle;
    private void OnTriggerEnter(Collider other)
    {
        
        Animator anim = other.GetComponentInChildren<Animator>();
        Animator selfAnim = GetComponentInChildren<Animator>();
        if (anim == null)
        {
            Debug.Log("No animator found");
        }
       
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(whistle, Camera.main.transform.position);
            anim.SetTrigger("Slip");
            selfAnim.SetTrigger("Joke");
            
            EventControl.OnJoke?.Invoke(funnyLevel);
            Destroy(gameObject, 1.5f);
        }
    }
}
