using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimClip : MonoBehaviour, IControlable
{
    private Animator animator;
    public string onState;

    public void TurnOff()
    {
        Debug.Log("anim turn off");
        animator.SetBool(onState, false);
    }

    public void TurnOn()
    {
        Debug.Log("anim turn on");
        animator.SetBool(onState, true);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
}
