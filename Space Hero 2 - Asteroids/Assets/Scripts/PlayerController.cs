using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SimpleHealthBar healthBar;
    [Space(10)]
    [Header("Ship Stats")]
    [SerializeField]
    float speed;
    [SerializeField]
    private float angularSpeed;
    [SerializeField]
    private float Acc = 5;
    [SerializeField]
    private float maxSpeed = 50;
    public GameObject explosion;

    [SerializeField]
    private float angleLimit = 10;          // Minimum accepted angle for movement change
    [SerializeField]
    private Transform gameMesh;

    float[] moveVector = new float[3];      // Change of movement vector depending on input

    Rigidbody rb;
    SpeedEffect sEffect;
    bool speedChanged;
    float attackTimer;
    bool returnOrigin;
    bool pressedx;
    bool pressedy;
    bool recover;
    public static int health = 100;
    bool takeDamage;
    int damageCounter;
    
    // Use this for initialization
    void Start()
    {
        speed = 100;
        rb = GetComponent<Rigidbody>();
        sEffect = GetComponent<SpeedEffect>();
        sEffect.SetMinMaxSpeed(20, maxSpeed);
        returnOrigin = false;
        pressedx = false;
        pressedy = false;
        recover = false;
        takeDamage = true;
        damageCounter = 30;
    }

    // Update is called once per frame
    void Update()
    {
       
            CheckKeyboardInput();
        

        MoveShip();
      
    }

    

    void CheckKeyboardInput()
    {


        //moveVector[0] = -Input.GetAxis("Vertical");
        //moveVector[1] = Input.GetAxis("Horizontal");
        moveVector[0] = (handDetection.calculatedHandPosition.y-180) / 180;
        moveVector[1] = (handDetection.calculatedHandPosition.x-230) / 230;


       
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.UpdateBar(health, 100);
    }

    void MoveShip()
    {
        damageCounter++;

        if (!Crash.crash && !recover)
        {
            Vector3 movement = Vector3.zero;

            movement += new Vector3(moveVector[0], moveVector[1], 0);

            Vector3 rot = movement.normalized * angularSpeed * Time.deltaTime;
            transform.Rotate(rot);
            Quaternion q = transform.rotation;
            q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
            transform.rotation = q;
        
        transform.position += transform.forward * Time.deltaTime * speed;
        }
        if (Crash.crash)
        {
            if (damageCounter > 30) { TakeDamage(20); damageCounter = 0; }

            Quaternion rot = Quaternion.FromToRotation(Vector3.up, Crash.contact.normal);
            Vector3 pos = Crash.contact.point;
            Instantiate(explosion, pos, rot);


            if (Crash.targetPosition.x > transform.position.x)
            {
               transform.LookAt(new Vector3(Crash.targetPosition.x,transform.position.y,transform.position.z+50));
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Crash.targetPosition.x+5, transform.position.y, transform.position.z), 20f * Time.deltaTime);
                transform.Rotate(-Vector3.forward * Time.deltaTime * 300);
                Debug.Log("CRASH");


                if (transform.position.x >= Crash.targetPosition.x)
                {
                    Crash.crash = false;
                    recover = true;
                }

            }

            if(Crash.targetPosition.x <= transform.position.x)
            {
                transform.LookAt(new Vector3(Crash.targetPosition.x, transform.position.y, transform.position.z + 50));
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Crash.targetPosition.x-5, transform.position.y, transform.position.z), 20f * Time.deltaTime);
                transform.Rotate(Vector3.forward * Time.deltaTime * 300);
                Debug.Log("crash");


                if (transform.position.x <= Crash.targetPosition.x)
                {
                    Crash.crash = false;
                    recover = true;
                }
            }


            if (Crash.targetPosition.y <= transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Crash.targetPosition.y-5, transform.position.z), 20f * Time.deltaTime);
                transform.Rotate(Vector3.up * Time.deltaTime * 300);
                Debug.Log("crash");


                if (transform.position.y <= Crash.targetPosition.y)
                {
                    Crash.crash = false;
                    recover = true;
                }
            }

            if (Crash.targetPosition.y > transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Crash.targetPosition.y+5, transform.position.z), 20f * Time.deltaTime);
                 transform.Rotate(-Vector3.up * Time.deltaTime * 300);
                Debug.Log("CRASH");


                if (transform.position.y >= Crash.targetPosition.y)
                {
                    Crash.crash = false;
                    recover = true;
                }

            }


        }

        if (recover)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, 60 * Time.deltaTime);
            Debug.Log("recover");
            if (transform.rotation == Quaternion.identity) { recover = false; }
        }

    }
    
    
}
