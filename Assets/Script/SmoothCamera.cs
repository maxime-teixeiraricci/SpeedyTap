using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{

    public Transform target;
    public Vector3 offsetVect;
    public float speed;


	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 vect = (target.position + offsetVect) - transform.position;
        transform.position += vect * speed * Time.deltaTime;
	}
}
