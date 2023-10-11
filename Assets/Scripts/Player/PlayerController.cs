using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private Vector3 playerVelocity;
    public float playerSpeed = 2.0f;
    public float transitionTime = .25f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float xSpeed = h * playerSpeed;
        float zSpeed = v * playerSpeed;
        float speed = Mathf.Sqrt(h*h+v*v);
        Vector3 move = new Vector3(h, 0, v);

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero) {
            gameObject.transform.forward = move;
        }
        animator.SetFloat("zSpeed", zSpeed, transitionTime, Time.deltaTime);
        animator.SetFloat("xSpeed", xSpeed, transitionTime, Time.deltaTime);
        animator.SetFloat("Speed", speed, transitionTime, Time.deltaTime);
    }
}
