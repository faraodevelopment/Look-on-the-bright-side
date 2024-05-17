using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBehavior : MonoBehaviour
{
    Transform playerBody;
    NavMeshAgent agent;
    Animator animator;
    float previousdistance;
    [SerializeField] float growthSpeed=0.001f;
    [SerializeField] float humorResistant = 0f;
    Vector3 originalSize;
    bool laughing;
    [SerializeField] AudioClip bounce;
    [SerializeField] AudioClip laugh;

    private void OnEnable()
    {
        EventControl.OnDialogComplete += LetsGo;
        EventControl.OnJoke += FilterJoke;
        EventControl.OnExitMessage += StopChase;
    }

    private void StopChase()
    {
        agent.SetDestination(transform.position);
    }

    private void FilterJoke(float intensity)
    {
        if(intensity > humorResistant)
        {
            humorResistant += intensity/4;
            StartCoroutine(Laughing(intensity));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerActions>().Tickle();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerBody = FindObjectOfType<PlayerMovement>().transform;
        agent = GetComponent<NavMeshAgent>();
        originalSize = transform.localScale;
        animator=GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void LetsGo()
    {

        agent.SetDestination(playerBody.position);
    }
    IEnumerator Laughing(float intens)
    {
        float laughtime = intens - humorResistant;
        if (laughtime > 0)
        {
            AudioSource.PlayClipAtPoint(laugh, Camera.main.transform.position);
            laughing = true;
            animator.SetTrigger("Laugh");
            yield return new WaitForSeconds(laughtime);
            DesizeEnemy();
            laughing = false;
        }
        else
        {
            yield return null;
        }
        
    }
    void ResizeEnemy()
    {
        previousdistance = 1000;
        float distance = Mathf.Abs(Vector3.Distance(transform.position, playerBody.position));
        if (distance < previousdistance ) { previousdistance = distance; transform.localScale = new Vector3(transform.localScale.x + growthSpeed, transform.localScale.x + growthSpeed, transform.localScale.x + growthSpeed); }
       
        
    }
    private void DesizeEnemy()
    {
        AudioSource.PlayClipAtPoint(bounce, transform.position);
        transform.localScale = originalSize;
    }
    private void Update()
    {
        if (!laughing)
        {
            ResizeEnemy();
            LetsGo();
        }
        
        
    }
}
