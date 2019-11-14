using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ControllableToggle
{
    public GameObject source;
    public bool switchState;
    private IControlable controlable;

    public void Initialize()
    {
        controlable = source.GetComponent<IControlable>();
    }

    public void ToggleOn()
    {
        if (controlable != null)
        {
            if (switchState) { controlable.TurnOn(); }
            else { controlable.TurnOff(); }
        }
    }

    public void ToggleOff()
    {
        if (controlable != null)
        {
            if (switchState) { controlable.TurnOff(); }
            else { controlable.TurnOn(); }
        }
    }
}
