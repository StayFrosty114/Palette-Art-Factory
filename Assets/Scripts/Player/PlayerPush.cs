using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPush : MonoBehaviour
{
    // this script pushes all rigidbodies that the character touches
    float pushPower = 2.0f;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Pushable")
        {
            Rigidbody body = hit.collider.attachedRigidbody;

            // no rigidbody
            if (body == null || body.isKinematic)
            {
                return;
            }

            // We dont want to push objects below us
            if (hit.moveDirection.y < -0.3)
            {
                return;
            }

            // Calculate push direction from move direction,
            // we only push objects to the sides never up and down
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            // If you know how fast your character is trying to move,
            // then you can also multiply the push velocity by that.

            // Apply the push
            body.velocity = pushDir * pushPower;

        }
    }

    private void FixedUpdate()
    {
    }


    /*
    public float thrust = 1.0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pushable")
        {
            Rigidbody body = collision.collider.attachedRigidbody;
            body.constraints = RigidbodyConstraints.FreezeRotation;

            if (body == null || body.isKinematic)
                return;

            body.AddForce(transform.forward * thrust, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Pushable")
        {
            Rigidbody body = collision.collider.attachedRigidbody;
            //body.constraints = RigidbodyConstraints.FreezeAll;
            body.velocity = Vector3.zero;
            //body.isKinematic = true;
        }
    }
    */


}
