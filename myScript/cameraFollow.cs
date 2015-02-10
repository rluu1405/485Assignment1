﻿using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	void Start()
	{
		offset = transform.position;
	}

	void LateUpdate()
	{
		transform.position = player.transform.position + offset;
	}
}
