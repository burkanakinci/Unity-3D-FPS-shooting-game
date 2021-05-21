using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public CharacterController characterController;

    Vector3 velocity;

    bool isGrounded;

    public Transform ground;

    public float distance = 0.3f;
    public float speed=20f;
    public float jumpingHeight;
    public float gravity;

    public LayerMask mask;
    GameManager gameManager;
    public FixedJoystick fixedJoystick;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        

        if (!gameManager.bulletObject.activeInHierarchy)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = transform.forward * fixedJoystick.Vertical + transform.right * fixedJoystick.Horizontal;
            Vector3 move = transform.right * horizontal + transform.forward * vertical;

            
            characterController.Move(direction * speed * Time.deltaTime);
            characterController.Move(move * speed * Time.deltaTime);
            
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {

                velocity.y = Mathf.Sqrt(jumpingHeight * (-3.0f) * gravity);
            }
        }
        

        

        isGrounded = Physics.CheckSphere(ground.position, distance, mask);

        if (isGrounded && velocity.y < 0)
        {

            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        

    }
}
