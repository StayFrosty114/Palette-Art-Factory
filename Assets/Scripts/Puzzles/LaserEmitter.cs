using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmitter : MonoBehaviour, ITrigger
{
    public bool activated;
    private LineRenderer lr;

    private void Awake()
    {
        activated = false;
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (activated)
        {
            lr.SetPosition(0, transform.position);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider)
                {
                    lr.SetPosition(1, hit.point);
                }
                if (hit.collider.GetComponent<LaserReflector>() != null)
                {
                    hit.collider.SendMessage("Activate");
                }
            }
            else
            {
                lr.SetPosition(1, transform.forward * 500);
            }
        }

    }

    public void Activate()
    {
        activated = true;
    }

    public void Deactivate()
    {
        activated = false;
        lr.SetPosition(0, new Vector3(0.0f, 0.0f, 0.0f));
        lr.SetPosition(1, new Vector3(0.0f, 0.0f, 0.0f));
    }

    public void Interact()
    {
        if (activated)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }
}
