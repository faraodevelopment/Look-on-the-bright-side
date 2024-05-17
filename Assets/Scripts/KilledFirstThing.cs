using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KilledFirstThing : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    float alpha = 0f;
    Image img;
    [SerializeField]bool goRed;
    [SerializeField]TMP_Text uitext;
    // Start is called before the first frame update
    void Start()
    {
        img=panel.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!goRed) return;
        killed();
    }
    public void GoRed()
    {
        goRed = true;
    }
    void killed()
    {
        if (alpha < 1f) alpha += 0.01f;
        img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
        if (alpha >= 1f)
        {
            uitext.gameObject.SetActive(true);
        }
    }
}
