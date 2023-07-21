using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballFling : MonoBehaviour
{

    public float ForceY = 100;
    public float ForceZ = 100;
    public float ForceT = 0;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 30;
        rb.AddForce(new Vector3(0, ForceY, ForceZ), ForceMode.VelocityChange);
        rb.AddTorque(new Vector3(ForceT, 0, 0), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(new Vector3(0, ForceY, ForceZ), ForceMode.Force);
        //rb.AddTorque(new Vector3(ForceT, 0, 0), ForceMode.Force);

    }
}
