using Game.Pandemonium.Cognitive;
using Game.Tank;
using UnityEngine;

namespace Game.Pandemonium
{
	public class Decision : MonoBehaviour
	{
		[SerializeField] private Vector2 target;
		private CognitiveMoveTarget cognitiveMoveTarget;
		private bool moveTargetFoundThisFrame = false;
		private bool moveTargetSeenByDriver = false;

		private Vector2 lastSeenEnemyPosition;
		private TankController tankController;

		private void Awake()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			cognitiveMoveTarget = GetComponent<CognitiveMoveTarget>();
			tankController = GetComponent<TankController>();
		}

		private void OnEnable()
		{
			cognitiveMoveTarget.OnPriorityMoveTargetSelected += OnTargetFound;
			cognitiveMoveTarget.OnPriorityMoveTargetSeenByDriver += OnTargetSeenByDriver;
		}

		private void OnTargetFound(Vector2 position)
		{
			moveTargetFoundThisFrame = true;
			target = position;
		}

		private void OnTargetSeenByDriver()
		{
			moveTargetSeenByDriver = true;
		}

		private void LateUpdate()
		{
			if (moveTargetFoundThisFrame)
			{
				tankController.RotateTowardsTarget(target);
				moveTargetFoundThisFrame = false;
				if (moveTargetSeenByDriver)
				{
					moveTargetSeenByDriver = false;
					tankController.MoveForward();
				}
			}
		}
	}
}