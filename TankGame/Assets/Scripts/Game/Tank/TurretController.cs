using UnityEngine;

namespace Game.Tank
{
	public class TurretController : MonoBehaviour {
		[SerializeField]
		private float rotationSpeed;

		private void Update()
		{
			TurnLeft();
		}
		
		public void TurnLeft()
		{
			transform.parent.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
		}
	
		public void TurnRight()
		{
			transform.parent.Rotate(-Vector3.forward, rotationSpeed * Time.deltaTime);
		}
	}
}
