using UnityEngine;
using System.Collections;

public class ChangeCameras: MonoBehaviour
{
	public Camera cameraMain;
	public Camera cameraLeft;
	public Camera cameraRight;

	void Start() {
		cameraMain.active = true;
		cameraLeft.active = false;
		cameraRight.active = false;
	}
	void Update () {
		if(Input.GetKey("q")){
			cameraMain.active = false;
			cameraLeft.active = true;
			cameraRight.active = false;
		}
		if(Input.GetKey("e")){
			cameraMain.active = false;
			cameraLeft.active = false;
			cameraRight.active = true;
		}
		if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
			cameraMain.active = true;
			cameraLeft.active = false;
			cameraRight.active = false;
		}
	}
}
