using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShootingSystem : MonoBehaviour
{
    RaycastHit hit;
    public GameObject rayPoint;
    public bool canFire;
    //public ParticleSystem muzzleFlash;
    //public AudioSource sesKaynak;
    //public AudioClip fireSound;

    public float range;

    void Start()
    {

        //sesKaynak = GetComponent<AudioSource>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && canFire)
        {

            //Fire();
        }
    }

    void Fire()
    {

        if (Physics.Raycast(rayPoint.transform.position, rayPoint.transform.forward, out hit, range))
        {

            //muzzleFlash.Play();
            //sesKaynak.Play();

            //sesKaynak.clip = fireSound;
            if(hit.transform.tag=="enemy" && hit.transform.GetComponent<EnemyController>().enabled==true)
            {

                hit.transform.gameObject.GetComponent<EnemyController>().health-=101;
            }
        }
    }
}
