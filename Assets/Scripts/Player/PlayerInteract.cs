using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public Transform head;
    public float interectRange;
    private bool m_Interact;
    public RectTransform crosshair;
    public float crosshairNormalSize = 10;
    public float crosshairInterectSize = 20;

    private void Start()
    {
        crosshair.sizeDelta = new Vector2(crosshairNormalSize, crosshairNormalSize);
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            m_Interact = true;
        }
    }

    private void FixedUpdate()
    {
        InteractCheck();
        m_Interact = false;
    }

    private void InteractCheck()
    {
        //Debug.DrawRay(head.position, head.forward * interectRange, Color.green);
        RaycastHit hit;
        Physics.Raycast(head.position, head.forward, out hit, interectRange);
        crosshair.sizeDelta = new Vector2(crosshairNormalSize, crosshairNormalSize);
        if (hit.collider)
        {
            GameObject gameObj = hit.collider.gameObject;
            ITrigger trigger = gameObj.GetComponent<ITrigger>();
            if (trigger != null)
            {
                crosshair.sizeDelta = new Vector2(crosshairInterectSize, crosshairInterectSize);
                if (m_Interact)
                {
                    trigger.Interact();
                }
            }
        }
    }

    //private void OnGUI()
    //{
    //    Texture2D texture = new Texture2D(100, 100, TextureFormat.RGBA32, false);
        
    //    Tex2DExtension.DrawCircle(ref texture, Color.black, 50, 50, 50);
    //    texture.Apply();
    //    Rect rect = new Rect(Screen.width * 0.5f, Screen.height * 0.5f, 100, 100);
    //    GUI.DrawTexture(rect, texture);
    //}
}
