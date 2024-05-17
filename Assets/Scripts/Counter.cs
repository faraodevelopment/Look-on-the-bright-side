using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    int counter;
    [SerializeField] AudioClip anger;
    AudioSource audioSource;
    bool killing;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void punched()
    {
        counter++;
        if (counter > 5)
        {
            if(!killing) 
            {
                killing = true;
                EventControl.OnVoice?.Invoke(anger);

                EventControl.OnAnger?.Invoke();
                counter = 0;
            }
            killing = false;
            
        }
    }
  
}
