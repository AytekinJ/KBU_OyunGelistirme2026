using System;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 10f;

    private Vector3 moveVector;
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // A = -1, D = 1, Left = -1 ve Right = 1
        float z = Input.GetAxis("Vertical"); // W = 1, S = -1, Up = 1 ve Down = -1
        moveVector = new Vector3(x, 0, z);
    }

    private void FixedUpdate()
    {
        transform.position += moveVector * Time.fixedDeltaTime * speed;

        if (moveVector != Vector3.zero)
        {
            animator.SetBool("isMoving", true);

            Quaternion targetRotation = Quaternion.LookRotation(-moveVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
        else
            animator.SetBool("isMoving", false);
    }
}