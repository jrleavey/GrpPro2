using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private AudioSource AudioSource;
    public AudioClip stunScream;
    public AudioClip gameOverScream;
    public AudioClip winSound;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject pCamera;
    public Text saltamount;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
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
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
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
        saltamount.text = "" + saltCount;
    }

    public void AddPrayerBead()
    {
        hasPrayerBead = true;
    }
    public void CaughtByMonster()
    {
        if (saltCount > 0)
        {
            saltCount--;
            saltamount.text = "" + saltCount;
            AudioSource.PlayClipAtPoint(stunScream, transform.position);
            return;
        }
        else if (saltCount == 0)
        {
            AudioSource.PlayClipAtPoint(gameOverScream, transform.position);
            loseScreen.SetActive(true);
            Time.timeScale = 0;
            pCamera.GetComponent<MouseLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bead")
        {
            obj1.SetActive(false);
            obj2.SetActive(true);
        }
        if (other.tag == "Win")
        {
            pCamera.GetComponent<MouseLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            winScreen.SetActive(true);
            AudioSource.PlayClipAtPoint(winSound, transform.position);
            Time.timeScale = 0;
        }
    }
}