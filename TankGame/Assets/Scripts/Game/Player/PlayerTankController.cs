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
		[SerializeField]
		private KeyCode shootCannon;
		private TankController tankController;
		private TurretController turretController;

		private void Awake()
		{
			tankController = transform.GetComponent<TankController>();
			turretController = transform.parent.GetComponentInChildren<TurretController>();
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
			
			if(Input.GetKeyDown(KeyCode.Space))
				turretController.Shoot();
			
			if(Input.GetKey(KeyCode.Q))
				turretController.TurnLeft();
			
			if(Input.GetKey(KeyCode.E))
				turretController.TurnRight();
		}
	}
}