using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour, ITrigger
{
    [SerializeField] private bool activated = false;
    [SerializeField] private bool timerEnabled = false;
    [SerializeField] private float timer = 3.0f;
    private float currTimer;
    public List<ControllableToggle> controllableToggles;

    private void Awake()
    {
        foreach (var toggle in controllableToggles)
        {
            toggle.Initialize();
        }
    }

    private void Update()
    {
        if (activated && timerEnabled)
        {
            currTimer -= Time.deltaTime;
            if (currTimer <= 0.0f)
            {
                Deactivate();
            }
        }
    }

    public void Activate()
    {
        currTimer = timer;
        activated = true;
        foreach(var toggle in controllableToggles)
        {
            toggle.ToggleOn();
        }
    }

    public void Deactivate()
    {
        activated = false;
        foreach (var toggle in controllableToggles)
        {
            toggle.ToggleOff();
        }
    }

    public void Interact()
    {
        // TODO: add options for what to do on interact
        //if (activated)
        //{
            // Deactivate();
        //    return;
        //}
        //else
        //{
            Activate();
        //}
    }
}
