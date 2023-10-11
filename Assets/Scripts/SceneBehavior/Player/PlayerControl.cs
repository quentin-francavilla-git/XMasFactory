using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private float xAxis;
    private float zAxis;
    public float walkSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInputs();
    }

    void GetInputs()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        Walk();
    }

    void Walk() {
        rb.velocity = new Vector3(xAxis * walkSpeed, rb.velocity.y, zAxis * walkSpeed);
    }
}
