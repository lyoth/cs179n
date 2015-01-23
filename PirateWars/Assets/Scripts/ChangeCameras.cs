using UnityEngine;
using System.Collections;

public class ChangeCameras: MonoBehaviour
{
	public Camera cameraMain;
	public Camera cameraLeft;
	public Camera cameraRight;

	void Start() {
		cameraMain.camera.active = true;
		cameraLeft.camera.active = false;
		cameraRight.camera.active = false;
	}
	void Update () {
		if(Input.GetKey("q")){
			cameraMain.camera.active = false;
			cameraLeft.camera.active = true;
			cameraRight.camera.active = false;
		}
		if(Input.GetKey("e")){
			cameraMain.camera.active = false;
			cameraLeft.camera.active = false;
			cameraRight.camera.active = true;
		}
		if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
			cameraMain.camera.active = true;
			cameraLeft.camera.active = false;
			cameraRight.camera.active = false;
		}
	}
}
