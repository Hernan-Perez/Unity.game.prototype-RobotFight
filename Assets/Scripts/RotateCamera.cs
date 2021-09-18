using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {

    private Transform target;
    public float vel = 3f;
    public float scrollSpeed = -10f;
    public float cameraDistance = 10f;

    public float cameraDistanceMin = 5f;
    public float cameraDistanceMax = 25f;
    private Rigidbody rb;
    //private Vector3 of;
    private float timerResetCamera = 1.5f;
    

    // Use this for initialization
    void Start () {
        target = transform.parent.transform;
        //of = new Vector3(0f, 4.25f, -8f);
        //of.Normalize();
        rb = target.GetComponentInParent<Rigidbody>();
        //Cursor.visible = false;
        ActualizarPosicionCamara();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ActualizarPosicionCamara();

        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(transform.parent.position, Vector3.up, Input.GetAxis("Mouse X") * vel);
            transform.RotateAround(transform.parent.position, Vector3.Cross(transform.forward, Vector3.up), Input.GetAxis("Mouse Y") * vel);
            Cursor.visible = false;
        }
        else
        {
            transform.LookAt(target);
            transform.RotateAround(transform.parent.position, Vector3.up, 0);
            Cursor.visible = true;
        }

        transform.LookAt(target);
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
        }
    }

    void ActualizarPosicionCamara()
    {
        Vector3 aux = transform.position - transform.parent.position;
        aux.Normalize();
        transform.position = transform.parent.position + aux * cameraDistance;
    }
}


