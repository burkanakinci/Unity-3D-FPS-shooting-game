using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody rigidbodyBullet;
    public GameObject rayPoint;

    public Transform parentObject;
    public float movementForce;
    Vector3 startingRot = new Vector3(-17.159f, 5f, -3.884f);
    Vector3 startingPos;
    private GameManager gameManager;
    private ScopeSystem scopeSystem;
    public FixedJoystick fixedJoystick;


    void OnDisable()
    {
        gameManager.SpawnEnemy();
        this.gameObject.transform.localPosition = startingPos;
        rigidbodyBullet.isKinematic = true;
        gameManager.currentState = GameManager.gameState.aim;
        //kamera eski haline dönecek
        //rigidbodyBullet.isKinematic=true;
    }
    void OnEnable()
    {

        gameManager.currentState = GameManager.gameState.fire;
        scopeSystem.isScoped = false;
        rigidbodyBullet.isKinematic = false;
        transform.SetParent(null);
        movementForce = 0.005f;
        //rigidbodyBullet.velocity=0f*rigidbodyBullet.velocity;
        //kamera mermiyi takip edecek
    }

    void Awake()
    {
        startingPos = this.gameObject.transform.localPosition;
        rigidbodyBullet.isKinematic = true;
        scopeSystem = FindObjectOfType<ScopeSystem>();
        gameManager = FindObjectOfType<GameManager>();

    }

    void FixedUpdate()
    {
        rigidbodyBullet.AddForce(rayPoint.transform.forward * movementForce);
    }
    void Update()
    {

        if (gameManager.currentState == GameManager.gameState.fire)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = transform.forward * fixedJoystick.Vertical + transform.right * fixedJoystick.Horizontal;

            if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Vertical") < 0.2f ||
                Input.GetAxis("Vertical") < 0 && Input.GetAxis("Vertical") > -0.2f ||
                Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0.2f ||
                Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > -0.2f)
            {

                movementForce = 2f;
            }
            else
            {

                movementForce = 0.2f;
            }
            transform.Translate(direction.x, direction.y, Time.deltaTime);
        }

        
        //BulletTranslate();
    }
    void BulletTranslate()
    {

        float yMovement = Input.GetAxis("Vertical") * 25;
        float xMovement = Input.GetAxis("Horizontal") * 25;

        yMovement *= Time.deltaTime;
        xMovement *= Time.deltaTime;

        transform.Translate(xMovement, yMovement, Time.deltaTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {


            other.gameObject.GetComponent<EnemyController>().health -=
                other.gameObject.GetComponent<EnemyController>().healthReduce;
        }
        this.transform.SetParent(parentObject.transform);
        this.gameObject.SetActive(false);
    }


}