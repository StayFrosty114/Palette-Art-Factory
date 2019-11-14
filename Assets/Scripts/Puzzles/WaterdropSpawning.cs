using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterdropSpawning : MonoBehaviour, IControlable
{

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
    public void TurnOff()
    {
    }
}
