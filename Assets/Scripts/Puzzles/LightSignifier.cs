using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSignifier : MonoBehaviour, IControlable
{
    private new Light light;
    public bool initialState = false;

    private void Awake()
    {    
        light = GetComponent<Light>();
        light.enabled = initialState;
    }

    public void TurnOff()
    {
        light.enabled = false;
    }

    public void TurnOn()
    {
        light.enabled = true;
    }
}
