using UnityEngine;
using System.Collections;

public class colTest : MonoBehaviour {
	
	//when a ridgidbody enters into the trigger area, an event triggers
	void OnTriggerEnter(Collider col)
	{
		Application.LoadLevel ("testScene2");
		Debug.Log ("it's in");
	}


}
