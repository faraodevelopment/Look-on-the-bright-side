using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webcamshow : MonoBehaviour
{
    WebCamTexture camTexture;

    // Start is called before the first frame update
    void Start()
    {
        camTexture= new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = camTexture;
        camTexture.Play();
    }

    private void OnEnable()
    {
        EventControl.OnWin +=()=> camTexture.Play();
    }
    private void OnDisable()
    {
        camTexture.Stop();
    }
}
