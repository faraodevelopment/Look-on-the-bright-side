using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomizeMenu : MonoBehaviour
{
    [SerializeField]
    GameObject buttonPrefab;
    [SerializeField]
    List<Sprite> m_MenuButtonImages = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i=0;i<40;i++)
        {
            int randomImage = Random.Range(0, m_MenuButtonImages.Count);
            GameObject go = Instantiate(buttonPrefab);
            Image[] images = go.GetComponentsInChildren<Image>();
            images[1].sprite=m_MenuButtonImages[randomImage];
            
            
            go.transform.SetParent(transform);
        }
    }

  
}
