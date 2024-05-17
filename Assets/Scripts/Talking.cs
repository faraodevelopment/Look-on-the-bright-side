using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Talking : MonoBehaviour
{
    [SerializeField] List<Sprite> images = new List<Sprite>();
    [SerializeField] float switchTime=1f;
    Image img;
    Coroutine routineTalk;
    bool talking = true;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        routineTalk = StartCoroutine("Talk");
    }

    IEnumerator Talk()
    {
        int i = 0;
        while (talking)
        {
            yield return new WaitForSeconds(switchTime);
            img.sprite = images[i];
            i++;
            if (i > images.Count-1)
            {
                i = 0;
            }
        }
        
    }
    
}
