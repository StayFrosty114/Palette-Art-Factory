using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public float pickUpRange;
    public Transform head;
    public KeyCode pickUpKey = KeyCode.Mouse0;
    public KeyCode dropKey = KeyCode.Mouse1;

    string pickUpTag = "PickUp";

    public Transform hand;
    
    private GameObject pickUpObject;

    public void Update()
    {
        // Pick Up
        RaycastHit hit;
        Ray ray = new Ray(head.position + head.forward * 1.0f, head.forward);
        if (pickUpObject != null)
        {
            pickUpObject.transform.localPosition = Vector3.zero;
        }

        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            if (hit.transform.CompareTag(pickUpTag) && Input.GetKeyDown(pickUpKey) && pickUpObject == null)
            {
                pickUpObject = hit.collider.gameObject;
                pickUpObject.transform.parent = hand;
               // pickUpObject.GetComponent<Rigidbody>().isKinematic = true;
                pickUpObject.GetComponent<Rigidbody>().useGravity = false;
                pickUpObject.transform.localPosition = Vector3.zero;
            }
        }

        // Drop
        if (Input.GetKeyDown(dropKey) && pickUpObject != null)
        {
            pickUpObject.transform.parent = null;
            //pickUpObject.GetComponent<Rigidbody>().isKinematic = false;
            pickUpObject.GetComponent<Rigidbody>().useGravity = true;
            pickUpObject = null;
        }
    }



}
