using Game.Pandemonium.Cognitive;
using Game.Tank;
using UnityEngine;

namespace Game.Pandemonium
{
	public class Decision : MonoBehaviour
	{
		[SerializeField] private Vector2 moveTarget;
		private Vector2 shootTarget;
		private CognitiveMoveTarget cognitiveMoveTarget;
		private CognitiveShootTarget cognitiveShootTarget;
		
		private bool moveTargetFoundThisFrame;
		private bool moveTargetSeenByDriver;
		private bool shootTargetFoundThisFrame = false;
		private bool shootTargetSeenByTurret = false;

		private Vector2 lastSeenEnemyPosition;
		private TankController tankController;
		private TurretController turretController;

		private void Awake()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			cognitiveMoveTarget = GetComponent<CognitiveMoveTarget>();
			cognitiveShootTarget = GetComponent<CognitiveShootTarget>();
			tankController = GetComponent<TankController>();
			turretController = transform.root.GetComponentInChildren<TurretController>();
		}

		private void OnEnable()
		{
			cognitiveMoveTarget.OnPriorityMoveTargetSelected += OnMoveTargetFound;
			cognitiveMoveTarget.OnPriorityMoveTargetSeenByDriver += OnMoveTargetSeenByDriver;
			cognitiveShootTarget.OnPriorityShootTargetSelected += OnShootTargetFound;
			cognitiveShootTarget.OnPriorityShootTargetSeenByTurret += OnShootTargetSeenByTurret;
		}

		private void OnMoveTargetFound(Vector2 position)
		{
			moveTargetFoundThisFrame = true;
			moveTarget = position;
		}

		private void OnShootTargetFound(Vector2 position)
		{
			shootTargetFoundThisFrame = true;
			shootTarget = position;
		}

		private void OnMoveTargetSeenByDriver()
		{
			moveTargetSeenByDriver = true;
		}
		
		private void OnShootTargetSeenByTurret()
		{
			shootTargetSeenByTurret = true;
		}

		private void LateUpdate()
		{
			if (moveTargetFoundThisFrame)
			{
				tankController.RotateTowardsTarget(moveTarget);
				moveTargetFoundThisFrame = false;
				if (moveTargetSeenByDriver)
				{
					moveTargetSeenByDriver = false;
					tankController.MoveForward();
				}
			}

			if (shootTargetFoundThisFrame)
			{
				turretController.RotateTowardsTarget(shootTarget);
				if (shootTargetSeenByTurret)
				{
					shootTargetSeenByTurret = false;
					turretController.Shoot();
				}
			}
		}
	}
}