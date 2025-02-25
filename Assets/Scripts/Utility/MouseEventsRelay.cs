using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEventsRelay : MonoBehaviour
{
    public GameObject relayTarget;

    private void OnMouseEnter()
    {
        if( relayTarget != null )
        {
            relayTarget.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnMouseOver()
    {
        if (relayTarget != null)
        {
            relayTarget.SendMessage("OnMouseOver", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnMouseExit()
    {
        if (relayTarget != null)
        {
            relayTarget.SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
        }
    }
}
