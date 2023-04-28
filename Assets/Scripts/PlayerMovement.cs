using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera camera2;
    public float tapSpeed = 0.5f;
    private float lastTapTime = 0;

    public float maxSpeed;
    public Rigidbody rb;
    private float horizontal;
    public float lastYPosition;
    public Canvas canvas;
    public float Stamina;
    public float DashCost;


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

    
    private void Start()
    {
        lastTapTime = 0;
        InvokeRepeating("addStamina", 2.0f, 0.3f);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void addStamina()
    {
        Stamina++;
      //  Debug.Log("Stamina Added");
    }

    void Update()
    {
        

        



        Vector2 positionOnScreen = (Vector2)Camera.main.WorldToViewportPoint(transform.position);
        

        Vector2 mouseOnScreen = (Vector2)camera2.ScreenToViewportPoint(Input.mousePosition);
        Vector2 mouseOnScreenScaled = positionOnScreen - mouseOnScreen;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if ((Time.time - lastTapTime) < tapSpeed)
            {
                if (Stamina > (DashCost - 1))
                {
                    //Debug.Log("DoubleTap Q");
                    PlayerBody.AddForce(-mouseOnScreenScaled * DashForce, ForceMode.Impulse);
                    Stamina = Stamina - DashCost;
                    Debug.Log(DashCost);
                    Debug.Log(Stamina);
                }
                else
                {
                    Debug.Log("Out Of Stamina");
                }
            }
            lastTapTime = Time.time;
        }

        Debug.DrawLine(positionOnScreen, mouseOnScreen, Color.green);
        Debug.DrawLine(-positionOnScreen, -mouseOnScreen, Color.red);
        Debug.DrawLine(-positionOnScreen, -mouseOnScreenScaled, Color.white);
      //  Debug.Log("mouseOnScreen :" + mouseOnScreen + ", Scaled: " + mouseOnScreenScaled  + " positionOnScreen :" + positionOnScreen);
      //  Debug.Log("ScaleFactor = " + canvas.scaleFactor);

        if (transform.position.y < -200)
        {
            transform.Translate(0,170,0);
            rb.AddForce(Vector3.down * 2);
            lastYPosition = transform.position.y;
           // Debug.Log("lastYPosition PlayerMovement : " + lastYPosition);

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

    


        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }


        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);



        if (Input.GetKeyDown(KeyCode.Space))
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
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            rb.velocity = Vector3.down * wallride;
        }
    }



    }
