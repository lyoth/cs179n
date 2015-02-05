using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	public void OnClickPlay(){
		Application.LoadLevel("Game Main");
	}
	void OnMouseOver () 
	{
		Screen.showCursor = false;
	}
}