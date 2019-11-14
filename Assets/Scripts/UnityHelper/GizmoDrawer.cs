using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawer : MonoBehaviour
{
    public enum GizmoShape
    {
        WireSphere = 0,
        Cube,
        Mesh
    };

    public enum GizmoColour
    {
        Blue, 
        Green,
        Red,
        Cyan,
    }

    public bool showGizmo = false;
    public GizmoShape shape = GizmoShape.Cube;
    public GizmoColour colour = GizmoColour.Blue;
    public float radius = 1.0f;
    public Vector3 scale = Vector3.one;

    public void OnDrawGizmos()
    {
        if (!showGizmo)
        {
            return;
        }
        switch (colour)
        {
            case GizmoColour.Blue:
                Gizmos.color = Color.blue;
                break;
            case GizmoColour.Green:
                Gizmos.color = Color.green;
                break;
            case GizmoColour.Red:
                Gizmos.color = Color.red;
                break;
            case GizmoColour.Cyan:
                Gizmos.color = Color.cyan;
                break;
        }
        switch (shape)
        {
            case GizmoShape.WireSphere:
                Gizmos.DrawWireSphere(transform.position, radius);
                break;
            case GizmoShape.Cube:
                Gizmos.DrawCube(transform.position, scale);
                break;
            case GizmoShape.Mesh:
                Gizmos.DrawMesh(GetComponent<MeshFilter>().sharedMesh, transform.position, transform.rotation, scale);
                break;
        }
    }
}
