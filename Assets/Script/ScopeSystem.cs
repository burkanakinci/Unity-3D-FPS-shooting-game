using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeSystem : MonoBehaviour
{
    public Vector3 nisanPos;
    public Vector3 normalPos;
    public Quaternion normalRot;
    public Quaternion nisanRot;
    public float aimSpeed;
    public bool isScoped;

    void Start()
    {
        isScoped = false;
        normalPos = transform.localPosition;
        normalRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (isScoped)
        {

            transform.localPosition =
                Vector3.Slerp(transform.localPosition, nisanPos, aimSpeed * Time.deltaTime);
            transform.localRotation =
                Quaternion.Slerp(transform.localRotation, Quaternion.Euler(nisanRot.x, nisanRot.y, nisanRot.z), aimSpeed * Time.deltaTime);
        }
        else
        {

            transform.localPosition =
                Vector3.Slerp(transform.localPosition, normalPos, aimSpeed * Time.deltaTime);
            transform.localRotation =
                Quaternion.Slerp(transform.localRotation, normalRot, aimSpeed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            isScoped = !isScoped;
            //düzeltirken de nisanPos a değil de normal pos'a gider
        }
    }

    public void Scopped(){

        isScoped = !isScoped;
    }
}
