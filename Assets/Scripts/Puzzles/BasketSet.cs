using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketSet : MonoBehaviour
{
    public Basket[] baskets;
    private bool[] basketsState;
    public List<ControllableToggle> signifiers;

    private void Awake()
    {
        foreach (var toggle in signifiers)
        {
            toggle.Initialize();
        }
        foreach (var basket in baskets)
        {
            basket.Initialize(this);
        }
        basketsState = new bool[baskets.Length];
        for (int i = 0; i < basketsState.Length ; ++i )
        {
            basketsState[i] = false;
        }
    }

    public void UpdateBasket(Basket basket)
    {
        for (int i = 0; i < baskets.Length; ++i)
        {
            if (basket.GetInstanceID() == baskets[i].GetInstanceID())
            {
                basketsState[i] = true;
                CheckState();
            }
        }
    }

    private void CheckState()
    {
        foreach (var state in basketsState)
        {
            if (!state) { return; }
        }
        Active();
    }

    private void Active()
    {
        foreach (var toggle in signifiers)
        {
            toggle.ToggleOn();
        }
    }
}
