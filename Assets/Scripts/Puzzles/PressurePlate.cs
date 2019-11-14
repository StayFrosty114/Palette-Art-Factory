using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public List<ControllableToggle> signifier;
    public GameObject plateObject;
    public int plateType = 0;
    public Vector3 offset = new Vector3(0.0f, 0.09f, 0.0f);
    private Rigidbody plateRb;
    private bool moved;

    private void Awake()
    {
        foreach (var toggle in signifier)
        {
            toggle.Initialize();
        }
        plateRb = plateObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PickUp") || other.CompareTag("Floor") || other.gameObject == plateObject)
        {
            return;
        }
        if (!moved)
        {
            moved = true;
            plateRb.MovePosition(transform.position - offset);
        }
        Pushable pushable = other.GetComponent<Pushable>();
        if ((pushable != null && pushable.pushableType == plateType))
        {
            foreach (var toggle in signifier)
            {
                toggle.ToggleOn();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PickUp")||other.CompareTag("Floor")|| other.gameObject == plateObject)
        {
            return;
        }
        if (moved)
        {
            moved = false;
            plateRb.MovePosition(transform.position);
        }
        Pushable pushable = other.GetComponent<Pushable>();
        if ((pushable != null && pushable.pushableType == plateType) || other.CompareTag("Player"))
        {
            foreach (var toggle in signifier)
            {
                toggle.ToggleOff();
            }

        }
    }
}
