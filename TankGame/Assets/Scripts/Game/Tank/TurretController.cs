using UnityEditor;
using UnityEngine;

namespace Game.Tank
{
	public class TurretController : MonoBehaviour
	{
		[SerializeField]
		private float rotationSpeed;

		private Cannon cannon;

		private void Awake()
		{
			cannon = transform.parent.GetComponentInChildren<Cannon>();
		}

		public void Shoot()
		{
			cannon.Shoot();
		}

		public void TurnLeft()
		{
			transform.parent.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
		}

		public void TurnRight()
		{
			transform.parent.Rotate(-Vector3.forward, rotationSpeed * Time.deltaTime);
		}
		
		public void RotateTowardsTarget(Vector2 position)
		{
			var desiredOrientation = Quaternion.LookRotation(Vector3.forward, position - (Vector2)transform.root.position);
			transform.parent.rotation = Quaternion.RotateTowards(transform.parent.rotation, desiredOrientation, rotationSpeed * Time.deltaTime * 5);
		}
	}
}