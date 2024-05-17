using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHands : MonoBehaviour
{
 
    public void CallHands()
    {
        EventControl.OnHands?.Invoke();
    }
}
