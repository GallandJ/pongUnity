
using UnityEngine;
using System.Collections;

/// <summary>
/// This behaviour is attached to the ball.
/// It controls the movement of the ball.
/// </summary>
public class Ball : MonoBehaviour
{

    private Rigidbody rb;
    public Vector3 initialImpulse;
    private Vector3 vel;


    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb.AddForce(initialImpulse, ForceMode.Impulse);
        }
        else
        {
            initialImpulse = -initialImpulse;
            rb.AddForce(initialImpulse, ForceMode.Impulse);
        }
    }

    void ResetBall()
    {
        rb.transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        //rb.velocity = initialImpulse;
        //transform.position = Vector3.zero;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("GoBall", 2);
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            vel.x = rb.velocity.x;
            vel.z = (rb.velocity.z/2.0f) + (collision.collider.attachedRigidbody.velocity.z/3.0f);
            rb.velocity = vel;
        }
    }
}