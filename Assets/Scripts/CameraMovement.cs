using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public Vector3 distanceFromTarget;
	void Start ()
    {
        distanceFromTarget = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = target.position + distanceFromTarget;
	}
}
