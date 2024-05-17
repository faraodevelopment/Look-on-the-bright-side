using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chaser : MonoBehaviour
{
    Button btn;
    [SerializeField]Image img;
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();
    int count;

    Vector2 chaseOffset=Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponentInParent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
     /*   if (transform.position.x < -Screen.width / 2) { btn.GetComponent<RectTransform>().position=new Vector2(-Screen.width / 2,btn.GetComponent<RectTransform>().position.y); chaseOffset -= chaseOffset; }
        if (transform.position.x > Screen.width / 2) { btn.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2, btn.GetComponent<RectTransform>().position.y); chaseOffset -= chaseOffset; }
        if(transform.position.y < -Screen.height / 2) { btn.GetComponent<RectTransform>().position = new Vector2(btn.GetComponent<RectTransform>().position.x, -Screen.height / 2); chaseOffset -= chaseOffset; }
        if(transform.position.y > Screen.height / 2) { btn.GetComponent<RectTransform>().position = new Vector2(btn.GetComponent<RectTransform>().position.x, Screen.height / 2); chaseOffset-=chaseOffset; }*/
    }
    private void OnMouseOver()
    {
        chaseOffset = new Vector2(Input.mousePosition.x, Input.mousePosition.y) + new Vector2(Random.Range(-25, 25), Random.Range(-25, 25));
        // chaseOffset -= chaseOffset;
        count++;
        if (count > 2) { img.sprite = sprites[0]; }
        if (count> 5) { img.sprite = sprites[1];}
        Debug.Log("mouse");
        btn.GetComponent<RectTransform>().position = chaseOffset;
    }
}
