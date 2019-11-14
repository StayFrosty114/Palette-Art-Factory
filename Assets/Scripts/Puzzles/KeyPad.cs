using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public List<ControllableToggle> successSignifier;
    public List<ControllableToggle> failSignifier;
    public List<MeshRenderer> lightSignifier;

    public Material defaultColor;
    public Material lightColor;
    public Material successColor;
    public Material failColor;

    public float resetTimer = 1.0f;
    private float _resetTimer;
    private bool waitingToReset;
    public int[] sequence;
    private int[] currSequence;
    private int currPos = 0;

    private bool locked = false;

    private void Awake()
    {
        currSequence = new int[sequence.Length];
        foreach (var light in lightSignifier)
        {
            light.material = defaultColor;
        }
        foreach (var toggle in successSignifier)
        {
            toggle.Initialize();
        }
        foreach (var toggle in failSignifier)
        {
            toggle.Initialize();
        }
    }

    private void Update()
    {
        if (waitingToReset)
        {
            _resetTimer -= Time.deltaTime;
            if (_resetTimer < 0.0f)
            {
                ResetSequence();
                waitingToReset = false;
            }
        }
    }

    public void UpdateKey(int index)
    {
        if (locked || waitingToReset|| currPos >= sequence.Length)
        {
            return;
        }
        currSequence[currPos] = index;
        lightSignifier[currPos].material = lightColor;
        currPos++;
        if (currPos == sequence.Length)
        {
            if (CheckSequence())
            {
                Success();
            }
            else
            {
                Fail();
            }
        }
    }

    private void ResetSequence()
    {
        currPos = 0;
        for (int i = 0; i < currSequence.Length; ++i)
        {
            currSequence[i] = -1;
        }
        foreach (var light in lightSignifier)
        {
            light.material = defaultColor;
        }
    }
    private bool CheckSequence()
    {
        for (int i = 0; i < currSequence.Length; ++i)
        {
            if (currSequence[i] != sequence[i])
            {
                return false;
            }
        }
        return true;
    }

    public void Success()
    {
        Debug.Log("Succeed");
        foreach (var toggle in successSignifier)
        {
            toggle.ToggleOn();
        }
        foreach (var light in lightSignifier)
        {
            light.material = successColor;
        }
        locked = true;
    }

    public void Fail()
    {
        Debug.Log("Failed");
        foreach (var toggle in failSignifier)
        {
            toggle.ToggleOn();
        }
        foreach (var light in lightSignifier)
        {
            light.material = failColor;
        }
        _resetTimer = resetTimer;
        waitingToReset = true;
    }
}
