using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballFling : MonoBehaviour
{

    public float ForceY = 100;
    public float ForceZ = 100;
    public float ForceT = 0;
    public Rigidbody rb;
    private float spin = 0.0f;
    private float power = 0.0f;
    private bool fire = false;
    private bool isMoving = false;
    private float time_init;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 30;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        SlowAfter4Seconds(); 

        if (fire == true)
        {
            rb.freezeRotation = false;
            rb.AddForce(new Vector3(0, ForceY*power, ForceZ * power), ForceMode.VelocityChange);
            rb.AddTorque(new Vector3(ForceT * (spin - 0.5f) * power, 0, 0), ForceMode.Impulse);

            fire = false;
        }
    }

    public void SetPower(float pow)
    {
        power = pow / 100;
    }

    public void SetSpin(float sp)
    {
        spin = sp / 100;
    }

    public void ReadyToFire()
    {
        fire = true;
    }

    private void SlowAfter4Seconds()
    {
        // as the function says. Slow down the ball every once in a while until it's a dead stop
        float tol = 10e-3f;
        if (!isMoving)
        {
            if(rb.velocity.magnitude > tol)
            {
                isMoving = true;
                time_init = Time.time;
            }
            else
            {
                rb.freezeRotation = true;
            }
        }

        else if (Time.time - time_init > 4)
        {
            isMoving = false;
            float rby = rb.angularVelocity.y;
            rb.angularVelocity = new Vector3(rb.angularVelocity.x * .7f, rb.angularVelocity.y * .7f, rb.angularVelocity.z * .7f);
            rb.velocity = new Vector3(rb.velocity.x *.8f, rb.velocity.y, rb.velocity.z*.8f);
        }


    }
}
