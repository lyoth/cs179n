using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour 
{
	float speed = 5.0f;
	float rotationSpeed = 0.3f;
	void Update()
	{
		rigidbody.AddRelativeForce (Vector3.forward * Input.GetAxis ("Vertical") * speed);
		transform.Rotate (Vector3.up * Input.GetAxis ("Horizontal") * rotationSpeed);
	}
}
