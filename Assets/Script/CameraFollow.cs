using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform mainCam;

    void LateUpdate()
    {
        if (target.gameObject.activeInHierarchy)
        {

            transform.position = Vector3.Lerp(transform.position, target.position , 6f*Time.deltaTime);
           // transform.position =Vector3.MoveTowards(transform.position, target.position, step);

            transform.LookAt(target);
        }
        else{
            transform.position = mainCam.position;
            transform.rotation = mainCam.rotation;
        }
    }
}
