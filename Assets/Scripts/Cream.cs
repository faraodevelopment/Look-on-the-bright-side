using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cream : MonoBehaviour
{
    
    public void StartCream()
    {
        GetComponent<ParticleSystem>().Play();
    }
}
