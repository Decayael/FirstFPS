using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class playerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;
    private bool sprinting;
    public float sprintSpeed = 8f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootingRate = 0.2f;
    private float shootCooldown = 0f;
    public float bulletForce = 20f;
    public InputManager inputManager;
    private GameObject bullet;
    private Vector3 aimingDirection = Vector3.forward;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

    }

    //receives inputs from inputmanager script and applies them to charactercontroller.
    public void Processmove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        // z because the joystick or keyboard translates up and down into forward and backwards instead.
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * speed * Time.deltaTime);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity = new Vector3(playerVelocity.x, jumpHeight, playerVelocity.z);
        }
    }
    public void Sprinting()
    {
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = sprintSpeed;
        }
        else if (!sprinting)
        {
            speed = 5f;
        }

    }
    public void SetAimingDirection(Vector3 direction)
    {
        aimingDirection = direction;
    }
    public void Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawnPoint.position, aimingDirection, out hit))
        {
            GameObject bullet = Instantiate(bulletPrefab, hit.point, Quaternion.LookRotation(hit.normal));

            if (bullet.GetComponent<Rigidbody>() != null)
            {
                bullet.GetComponent<Rigidbody>().AddForce(aimingDirection * bulletForce, ForceMode.Impulse);
            }

            Destroy(bullet, 2.0f); // Destroy bullet after 2 seconds
        }
        else
        {
            // if the raycast doesn't hit anything bullet flies
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.LookRotation(aimingDirection));

            if (bullet.GetComponent<Rigidbody>() != null)
            {
                bullet.GetComponent<Rigidbody>().AddForce(aimingDirection * bulletForce, ForceMode.Impulse);
            }

            Destroy(bullet, 2.0f); // Destroy bullet after 2 seconds
        }
    }

}


