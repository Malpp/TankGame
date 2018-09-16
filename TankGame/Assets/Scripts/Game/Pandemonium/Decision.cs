using Game.Pandemonium.Cognitive;
using Game.Tank;
using UnityEngine;

namespace Game.Pandemonium
{
	public class Decision : MonoBehaviour
	{
		[SerializeField] private Vector2 target;
		private Transform rootTransform;
		private CognitiveMoveTarget cognitiveMoveTarget;

		private Vector2 lastSeenEnemyPosition;
		private TankController tankController;

		private void Awake()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			rootTransform = transform.root;
			cognitiveMoveTarget = GetComponent<CognitiveMoveTarget>();
			tankController = GetComponent<TankController>();
		}

		private void OnEnable()
		{
			cognitiveMoveTarget.OnPriorityMoveTargetSelected += OnTargetFound;
		}

		private void OnTargetFound(Vector2 position)
		{
			target = position;
			tankController.MoveForward();
		}
	}
}