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

    private void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
        scopeSystem = FindObjectOfType<ScopeSystem>();

        sensitivity = 200f;
    }
    private void Update()
    {
        if (scopeSystem.isScoped) { 
            sensitivity = 10; }
        else { 
            sensitivity = 200; }
        if (gameManager.currentState != GameManager.gameState.fire)
        {
            float rotX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
            float rotY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

            xRotation -= rotY;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);//rotation sınırlandırması için

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            body.Rotate(Vector3.up * rotX);
        }


    }

}
