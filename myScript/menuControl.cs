using UnityEngine;
using System.Collections;

public class menuControl : MonoBehaviour {

	bool guiOn = false;

	void Update() {
		if (Input.GetKey("escape"))
			Application.Quit();	
		StartCoroutine ("timeIt");
	}

	IEnumerator timeIt()
	{
		Debug.Log ("time it");
		yield return new WaitForSeconds(2);
		Debug.Log ("GUI turn");
		guiOn = true;
	}

	void OnGUI()
	{
		if(guiOn){
			if (GUI.Button (new Rect (200,200,200,20), "Restart?")) {
				Application.LoadLevel("testScene1");
			}
		}
	}

}
