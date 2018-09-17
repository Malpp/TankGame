using Game.Tank;
using UnityEngine;

namespace Game.Player
{
	public class PlayerTankController : MonoBehaviour
	{
		[SerializeField]
		private KeyCode moveTankForward;
		[SerializeField]
		private KeyCode moveTankBackward;
		[SerializeField]
		private KeyCode turnTankLeft;
		[SerializeField]
		private KeyCode turnTankRight;
		private TankController tankController;

		private void Awake()
		{
			tankController = transform.GetComponent<TankController>();
		}

		private void Update()
		{
			if (Input.GetKey(moveTankForward))
				tankController.MoveForward();

			if (Input.GetKey(turnTankLeft))
				tankController.TurnLeft();

			if (Input.GetKey(moveTankBackward))
				tankController.MoveBackward();

			if (Input.GetKey(turnTankRight))
				tankController.TurnRight();
		}
	}
}