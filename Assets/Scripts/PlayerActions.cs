using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    public float threshold { get; private set; } = 3f;
    public float intensityTimer { get; private set; } = 0.0f;

    
    public float health { get; private set; } = 100f;
    [SerializeField]
    AudioClip tickle;
    [SerializeField]
    AudioClip tickleDie;
    AudioSource audioSource;
    [SerializeField]
    float damage=5f;
    public void Tickle()
    {
        
        if (health > 0f)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.clip = tickle;
                audioSource.Play();
            }

            health -= damage;
           // EventControl.OnHealth?.Invoke(health);

            
        }
        else 
        {
            audioSource.Stop();
            audioSource.clip = tickleDie; audioSource.Play();
            GetComponentInChildren<Animator>().SetTrigger("Die");
            EventControl.OnGameOver?.Invoke();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        intensityTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)&&intensityTimer>=threshold)
        {
            EventControl.OnJoke?.Invoke(intensityTimer);
            intensityTimer = 0.0f;
        }
    }
}
