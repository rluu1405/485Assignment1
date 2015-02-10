using UnityEngine;
using System.Collections;

public class moveRig : MonoBehaviour {

	public float moveHorizontal = 30.0f;
	public float jumpHeight = 2.0f;
	public Vector3 offset;

	public float xMin, xMax, yMin, yMax, zMin, zMax;

	Vector3 movement;
	Vector3 currentMovement;

	void Start()
	{
		offset = new Vector3 (0.5f, 0.25f, 0.0f);
	}

	void Update()
	{
		//Vector3 forward = transform.TransformDirection(Vector3.down) * 10;
		Debug.DrawRay(transform.position + offset, Vector3.down, Color.red);
		Debug.DrawRay(transform.position, Vector3.right, Color.red);
	}

	void FixedUpdate()
	{
		playerMove ();
	}

	void playerMove()
	{

		//need to clamp the boundry with Math.Clamp(value, min, max), instead of using walls

		movement.x = Input.GetAxis ("Horizontal");

		if(hitGround() && Input.GetButton("Jump"))
		{

			playerJump ();

		}


		if(!hitGround())
		{
			movement.y = 0.0f;
		}
		else
		{

			rigidbody.AddForce(movement * moveHorizontal);

			rigidbody.position = new Vector3 (Mathf.Clamp (rigidbody.position.x, xMin, xMax), Mathf.Clamp (rigidbody.position.y, yMin, yMax), Mathf.Clamp (rigidbody.position.z, zMin, zMax));
		
		}

	}

	void playerJump()
	{
		movement.y = jumpHeight;
		rigidbody.AddForce(movement, ForceMode.Impulse);
	}

	bool hitGround()
	{


		if (Physics.Raycast(transform.position + offset, Vector3.down, 1.0f))
		{
			if(Physics.Raycast(transform.position, Vector3.right, 1.0f))
			{
				Debug.Log("something is there");
			}

			Debug.Log("is on the ground");
			return true;
		}
		else
		{
			Debug.Log("is not on the ground");
			return false;
		}
	}
}
