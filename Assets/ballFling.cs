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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (fire == true)
        {
            rb.AddForce(new Vector3(0, ForceY*power, ForceZ * power), ForceMode.VelocityChange);
            rb.AddTorque(new Vector3(ForceT * (spin - 0.5f), 0, 0), ForceMode.Impulse);

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
}
