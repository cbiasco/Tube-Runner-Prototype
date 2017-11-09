﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour {

	[SerializeField]
	private float rotationSpeed = 30f;

	private void Update()
	{
		transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
