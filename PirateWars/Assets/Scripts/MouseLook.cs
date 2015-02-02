using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {


	public float mouseSensitivity = 100f;

	Transform myCamera;
	float maxVertical;
	float maxHoriz;
	// Use this for initialization
	void Start () {
	//		myCamera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0);
		
		maxVertical += Input.GetAxis ("Mouse Y") * Time.deltaTime * mouseSensitivity;
		maxVertical = Mathf.Clamp (maxVertical, 0, 60);
		transform.localEulerAngles = new Vector3(-maxVertical, transform.localEulerAngles.y, 0);
	}

}
