using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : StaminaBar
{
    public Vector3Value positionValue;
    
    public Camera camera2;
    public float tapSpeed = 0.5f;
    private float lastTapTime = 0;

    public float maxSpeed;
    public float maxSpeedIncrementRate = 0.1f; // Rate at which the max speed increases per second
    private float elapsedTime = 0f; // Elapsed time since the start of the game
    public Rigidbody rb;
    private float horizontal;
    public float lastYPosition;
    public Canvas canvas;
    public int DashCost;
    public int JumpCost;
    public float HP = 3;
    public int ammoCount = 999;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private float Speed;

    [SerializeField] private float JumpForce;
    [SerializeField] private float DashForce;
    [SerializeField] private float Velocity;

    [SerializeField] private float wallride;
    [SerializeField] public float kickbackForce;

    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    public GameEvent onPlayerdamage;
    public playerhealth Hp;
    public GameEvent onPlayerdeath;

    public ParticleSystem mainBurst;
    public ParticleSystem secondaryBurst;

    private void Start()
    {
        lastTapTime = 0;
        camera2 = Camera.main;
        mainBurst.Stop();
        secondaryBurst.Stop();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime; // Update the elapsed time

        positionValue.position = transform.position;
        Vector2 positionOnScreen = (Vector2)Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)camera2.ScreenToViewportPoint(Input.mousePosition);
        Vector2 mouseOnScreenScaled = positionOnScreen - mouseOnScreen;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if ((Time.time - lastTapTime) < tapSpeed && staminaBar.value >= DashCost)
            {
                PlayerBody.AddRelativeForce((GameObject.FindGameObjectWithTag("BulletTransform").transform.position - transform.position) * DashForce, ForceMode.VelocityChange);
                StaminaBar.instance.UseStamina(DashCost);
            }
            lastTapTime = Time.time;
        }

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire && ammoCount > 0)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            ammoCount--;
            Debug.Log("Ammo Count" + ammoCount);

            Vector3 kickbackDirection = -transform.forward; // Adjust the kickback direction as needed
            ApplyKickbackForce(kickbackDirection * kickbackForce);
        }

        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && staminaBar.value >= JumpCost)
        {
            PlayerJump();
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        // Increase max speed over time
        maxSpeed = Mathf.Lerp(maxSpeed, maxSpeed + maxSpeedIncrementRate, elapsedTime);

    }

    public void ApplyKickbackForce(Vector3 force)
    {
        rb.AddForce(force, ForceMode.Impulse);
    }

    private void PlayerJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reset vertical velocity to 0
        Vector3 jumpVector = new Vector3(0, JumpForce, 0);
        rb.AddForce(jumpVector);
        StaminaBar.instance.UseStamina(JumpCost);

        ActivateBurst();
    }

    private void ActivateBurst()
    {
        mainBurst.Play();
        secondaryBurst.Play();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            rb.velocity = Vector3.down * wallride;
        }

        if (collision.gameObject.tag == "enemy")
        {
            Demage();
        }

        if (collision.gameObject.tag == "Spikes")
        {
            Demage();
        }
    }

    public void Demage()
    {
        Hp.value -= 1;
        if (onPlayerdamage != null)
            onPlayerdamage.Fire();
        camera2.transform.DOShakePosition(1f);
    }
}
