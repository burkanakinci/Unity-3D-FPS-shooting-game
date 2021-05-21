using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity;
    public Transform body;
    float xRotation = 0f;
    private GameManager gameManager;
    private ScopeSystem scopeSystem;
    public TouchLook touchController;
    private float limitX, limitY;
    private float xRot, yRot;

    private void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
        scopeSystem = FindObjectOfType<ScopeSystem>();

        sensitivity = 20f;
    }
    private void Update()
    {

        if (scopeSystem.isScoped)
        {
            sensitivity = 10;
        }
        else
        {
            sensitivity = 50;
        }
        // if (gameManager.currentState != GameManager.gameState.fire)
        // {
        //     float rotX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        //     float rotY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        //     xRotation -= rotY;
        //     xRotation = Mathf.Clamp(xRotation, -80f, 80f);//rotation sınırlandırması için

        //     transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //     body.Rotate(Vector3.up * rotX);
        // }

    }
    private void FixedUpdate()
    {

        limitX = touchController.SlideHorizontal*sensitivity*Time.fixedDeltaTime;
        limitY = -touchController.SlideVertical*sensitivity*Time.fixedDeltaTime;

        xRot = Mathf.Clamp(limitY, min: -90, max: 90);
        yRot = Mathf.Clamp(limitX, min: -90, max: 90);

        transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);
    }
}
