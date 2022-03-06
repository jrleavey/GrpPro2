using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public float saltCount = 0;
    public float groundDistance;
    public LayerMask groundMask;
    public Transform groundCheck;
    public bool hasPrayerBead = false;
    public GameObject candleLight;
    public bool isLightOn = true;

    Vector3 Velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.F) && isLightOn == true)
        {
            candleLight.SetActive(false);
            isLightOn = false;
        }
        else if (Input.GetKeyDown(KeyCode.F) && isLightOn == false)
        {
            candleLight.SetActive(true);
            isLightOn = true;
        }
    }


    public void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        Velocity.y += gravity * Time.deltaTime;

        controller.Move(Velocity * Time.deltaTime);
    }

    public void AddSaltCount()
    {
        saltCount++;
    }

    public void AddPrayerBead()
    {
        hasPrayerBead = true;
    }
}