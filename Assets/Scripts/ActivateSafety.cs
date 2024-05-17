using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSafety : MonoBehaviour
{
    [SerializeField]
    GameObject m_gameObject;

    private void OnEnable()
    {
        EventControl.OnSafety += ShowPanel;    
    }
    void ShowPanel()
    {
        m_gameObject.SetActive(true);
    }
 
}
