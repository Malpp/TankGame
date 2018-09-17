using Game.Pandemonium.Feature;
using UnityEngine;

namespace Game.Pandemonium.Cognitive
{
	public delegate void TopPriorityShootTargetEventHandler(Vector2 position);
	public delegate void TopPriorityShootTargetSeenByTurretEventHandler();
	
	public class CognitiveShootTarget : MonoBehaviour
	{
		public event TopPriorityShootTargetEventHandler OnPriorityShootTargetSelected;
		public event TopPriorityShootTargetSeenByTurretEventHandler OnPriorityShootTargetSeenByTurret;

		private FeatureEnemy featureEnemy;

		private Vector2 lastSeenEnemyPosition;

		private void Awake()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			featureEnemy = GetComponent<FeatureEnemy>();
		}

		private void OnEnable()
		{
			featureEnemy.OnEnemySeenByDriver += OnEnemySeen;
			featureEnemy.OnEnemySeenByCommander += OnEnemySeen;
			featureEnemy.OnEnemySeenByTurret += OnEnemySeen;
			featureEnemy.OnEnemySeenByTurret += OnEnemySeenByTurret;
		}

		private void OnEnemySeen(Vector2 position)
		{
			lastSeenEnemyPosition = position;
			OnPriorityShootTargetSelected?.Invoke(lastSeenEnemyPosition);
		}

		private void OnEnemySeenByTurret(Vector2 position)
		{
			OnPriorityShootTargetSeenByTurret?.Invoke();
		}
	}
}