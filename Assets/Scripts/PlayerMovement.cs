using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : StaminaBar
{
    public Camera camera2;
    public float tapSpeed = 0.5f;
    private float lastTapTime = 0;

    public float maxSpeed;
    public Rigidbody rb;
    private float horizontal;
    public float lastYPosition;
    public Canvas canvas;
    public int DashCost;
    public int JumpCost;
    public float HP = 3;


    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private float Speed;

    [SerializeField] private float JumpForce;
    [SerializeField] private float DashForce;
    [SerializeField] private float Velocity;

    [SerializeField] private float wallride;

    
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;


    public GameEvent onPlayerdamage;
    public playerhealth Hp;
    public GameEvent onPlayerdeath;



    private void Start()
    {
        lastTapTime = 0;
        camera2 = Camera.main;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
  

    void Update()
    {
        

        



        Vector2 positionOnScreen = (Vector2)Camera.main.WorldToViewportPoint(transform.position);
        

        Vector2 mouseOnScreen = (Vector2)camera2.ScreenToViewportPoint(Input.mousePosition);
        Vector2 mouseOnScreenScaled = positionOnScreen - mouseOnScreen;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if ((Time.time - lastTapTime) < tapSpeed && staminaBar.value >= DashCost)
            {
               
                    //Debug.Log("DoubleTap Q");
                   // PlayerBody.AddForce(-mouseOnScreenScaled * DashForce, ForceMode.Impulse);
                PlayerBody.AddRelativeForce((GameObject.FindGameObjectWithTag("BulletTransform").transform.position - transform.position) * DashForce, ForceMode.VelocityChange);
                StaminaBar.instance.UseStamina(DashCost);
              
               
            }
            lastTapTime = Time.time;
        }
        /*
        Debug.DrawLine(positionOnScreen, mouseOnScreen, Color.green);
        Debug.DrawLine(-positionOnScreen, -mouseOnScreen, Color.red);
        Debug.DrawLine(-positionOnScreen, -mouseOnScreenScaled, Color.white);
        Debug.DrawLine(-mouseOnScreenScaled, new Vector3(0, 0), Color.black); */
        //  Debug.Log("mouseOnScreen :" + mouseOnScreen + ", Scaled: " + mouseOnScreenScaled  + " positionOnScreen :" + positionOnScreen);
        //  Debug.Log("ScaleFactor = " + canvas.scaleFactor);

        //if (transform.position.y < -200)
        //{
        //    transform.Translate(0, 170, 0);
        //    rb.AddForce(Vector3.down * 2);
        //    lastYPosition = transform.position.y;
        //    // Debug.Log("lastYPosition PlayerMovement : " + lastYPosition);

        //}



        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

    


        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }


        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);



        if (Input.GetKeyDown(KeyCode.Space) && staminaBar.value >= JumpCost)
        {
            PlayerJump();
        }

        //Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            //Debug.Log(rb.velocity);
        }
        


    }

    private void PlayerJump()
    {
        Vector3 jumpVector = new Vector3(0, JumpForce, 0);
        rb.AddForce(jumpVector);
        StaminaBar.instance.UseStamina(JumpCost);


    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            rb.velocity = Vector3.down * wallride;
        }


        if (collision.gameObject.tag == "enemy")
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
