using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float tapSpeed = 0.5f;
    private float lastTapTime = 0;

    public float maxSpeed;
    public Rigidbody rb;
    private float horizontal;


    private bool grounded = false;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private float Speed;

    [SerializeField] private float JumpForce;
    [SerializeField] private float DashForce;
    [SerializeField] private float Velocity;

    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    
    private void Start()
    {
        lastTapTime = 0;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }


    private void Update()
    {
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



        
        if (Input.GetKeyDown(KeyCode.A))
        {
            if((Time.time - lastTapTime) < tapSpeed)
            {
                //Debug.Log("DoubleTap A");
                PlayerBody.AddForce(Vector3.left * DashForce, ForceMode.Impulse);
            }
            lastTapTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if ((Time.time - lastTapTime) < tapSpeed)
            {
                //Debug.Log("DoubleTap A");
                PlayerBody.AddForce(Vector3.right * DashForce, ForceMode.Impulse);
            }
            lastTapTime = Time.time;
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

    

}
