using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour, ITrigger
{
    public int index;
    KeyPad pad;


    private void Awake()
    {
        pad = transform.parent.GetComponent<KeyPad>();
    }

    public void Activate()
    {
        Debug.Log("Pressed " + index);
        pad.UpdateKey(index);
    }

    public void Deactivate()
    {
        return;
    }

    public void Interact()
    {
        Activate();
    }

}
