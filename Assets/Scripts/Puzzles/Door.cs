using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IControlable
{
    public GameObject doorObject;
    public Transform startPos;
    public Transform endPos;

    // TODO add Lerp Rotation
    public float movingTime;
    public bool initialState = true;
    private bool isMoving = false;

    private void Awake()
    {
        if (initialState)
        {
            doorObject.transform.position = startPos.position;
        }
        else
        {
            doorObject.transform.position = endPos.position;
        }
    }

    public void TurnOff()
    {
        if (!isMoving)
        {
            StartCoroutine(Move(startPos, endPos));
        }
    }

    public void TurnOn()
    {
        if (!isMoving)
        {
            StartCoroutine(Move(endPos, startPos));
        }
    }

    public IEnumerator Move(Transform start, Transform end)
    {
        if (Vector3.Distance(end.position, doorObject.transform.position) < 1.0f)
        {
            yield return null;
        }
        else
        {
            isMoving = true;
            float t = 0;

            while (t <= 1)
            {
                t += Time.deltaTime / movingTime;
                
                doorObject.transform.position = Vector3.Lerp(start.position, end.position, t);
                doorObject.transform.rotation = Quaternion.Lerp(start.rotation, end.rotation, t);                
                //doorObject.transform.position = start.position + (end.position - start.position) * t;
                yield return null;
            }
            isMoving = false;
        }
    }

}
