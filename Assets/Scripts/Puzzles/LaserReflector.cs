using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReflector : MonoBehaviour
{
    private bool rayActivated;
    private LineRenderer lr;

    private void Awake()
    {
        rayActivated = false;
        lr = GetComponent<LineRenderer>();
    }

    public void Activate()
    {
        rayActivated = true;
        Debug.Log("Get shoot");
    }

    private void Update()
    {
        if (rayActivated)
        {
            lr.SetPosition(0, transform.position);
            Ray ray = new Ray(this.transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider)
                {
                    hit.collider.SendMessage("Activate");
                    lr.SetPosition(1, hit.point);
                }
            }
            else
            {
                lr.SetPosition(1, transform.forward * 500);
            }
        }
        else
        {
            lr.SetPosition(0, new Vector3(0.0f, 0.0f, 0.0f));
            lr.SetPosition(1, new Vector3(0.0f, 0.0f, 0.0f));
        }
        rayActivated = false;
    }

}
