﻿using UnityEngine;

namespace Game.Tank
{
	public class TankController : MonoBehaviour
	{
		[SerializeField]
		private float moveSpeed = 10f;
		[SerializeField]
		private float rotationSpeed = 10f;
		private Rigidbody2D body;

		private void Awake()
		{
			body = transform.parent.GetComponent<Rigidbody2D>();
		}

		public void MoveForward()
		{
			body.AddRelativeForce(Vector2.up * Time.deltaTime * moveSpeed);
		}

		public void MoveBackward()
		{
			body.AddRelativeForce(Vector2.down * Time.deltaTime * moveSpeed);
		}

		public void TurnLeft()
		{
			body.AddTorque(rotationSpeed * Time.deltaTime);
		}

		public void TurnRight()
		{
			body.AddTorque(-rotationSpeed * Time.deltaTime);
		}

		public void RotateTowardsTarget(Vector2 position)
		{
			var desiredOrientation = Quaternion.LookRotation(Vector3.forward, position - (Vector2)transform.root.position);
			transform.root.rotation = Quaternion.RotateTowards(transform.root.rotation, desiredOrientation, rotationSpeed * Time.deltaTime * 5);
		}
	}
}