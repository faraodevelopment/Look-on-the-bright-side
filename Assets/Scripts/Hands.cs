using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventControl.OnHands += ShowHands;
        EventControl.OnHandsOut += HideHands;
    }
   
    void ShowHands()
    {
        anim.SetTrigger("In");
    }
    public void HideHands()
    {
        anim.SetTrigger("Out");
    }
}
