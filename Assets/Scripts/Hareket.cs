using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Hareket : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = -30f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float jumpHeight = 4f;

    private Vector3 lastPosition;
    private Vector3 moveVector;
    private float velocityY;
    private bool isJumping;
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        InputHandling();
        Movement();
        Rotation();
        AnimatorVariables();
    }
    
    void Movement()
    {
        //karakter yerdeyse düşme hızını sabitle
        if(_characterController.isGrounded && velocityY < 0f)
        {
            velocityY = -1f;
        }
        
        //zıplama mekaniği
        if(isJumping && _characterController.isGrounded)
        {
            //hız formülü hız = kök(yükseklik * 2 * yer çekimi), -2 yazdık çünkü yukarı zıplasın istiyoz
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        isJumping = false;

        //yer çekimini uygula
        velocityY += gravity * Time.deltaTime;

        //karakteri hareket ettir
        Vector3 velocity = moveVector * speed;
        velocity.y = velocityY;

        _characterController.Move(velocity * Time.deltaTime);
    }

    void Rotation()
    {
        if (moveVector != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void AnimatorVariables()
    {
        animator.SetBool("isMoving", _characterController.velocity != Vector3.zero);
    }

    void InputHandling()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        moveVector = new Vector3(x, 0, z).normalized;

        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        if(Input.GetButtonUp("Jump") && velocityY > 0f)
        {
            velocityY /= 2;
        }
    }
}