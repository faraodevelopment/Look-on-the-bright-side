using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    Image img;
    PlayerActions pa;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        pa = FindObjectOfType<PlayerActions>();
        img.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = pa.health / 100;
    }
}
