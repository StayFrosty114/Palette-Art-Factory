using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public GameObject lid;
    private BasketSet basketSet;

    public void Initialize(BasketSet BasketSet)
    {
        basketSet = BasketSet;
    }

    private void Awake()
    {
        lid.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            lid.SetActive(true);
            basketSet.UpdateBasket(this);
        }
    }
}
