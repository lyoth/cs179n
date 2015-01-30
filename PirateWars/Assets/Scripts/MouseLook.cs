using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public float mouseSensitivity = 100f;
	Transform myCamera;
	float maxVertical;
	// Use this for initialization
	void Start () {
		myCamera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Input.GetAxis ("Mouse X") * Time.deltaTime * mouseSensitivity);
		maxVertical += Input.GetAxis ("Mouse Y") * Time.deltaTime * mouseSensitivity;
		maxVertical = Mathf.Clamp (maxVertical, -60, 60);
		myCamera.localEulerAngles = Vector3.left * maxVertical;
	}
}
