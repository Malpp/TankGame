using System.Collections.Generic;
using Game.Pandemonium.Feature;
using UnityEngine;

namespace Game.Pandemonium.Cognitive
{
	public delegate void TopPriorityMoveTargetEventHandler(Vector2 position);

	public delegate void TopPriorityMoveTargetSeenByDriverEventHandler();
	
	public class CognitiveMoveTarget : MonoBehaviour
	{
		public event TopPriorityMoveTargetEventHandler OnPriorityMoveTargetSelected;
		public event TopPriorityMoveTargetSeenByDriverEventHandler OnPriorityMoveTargetSeenByDriver;
		
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
			featureEnemy.OnEnemySeenByDriver += OnEnemySeenByDriver;
			featureEnemy.OnEnemySeenByCommander += OnEnemySeen;
			featureEnemy.OnEnemySeenByTurret += OnEnemySeen;
		}

		private void OnEnemySeen(Vector2 position)
		{
			lastSeenEnemyPosition = position;
			OnPriorityMoveTargetSelected?.Invoke(lastSeenEnemyPosition);
		}
		
		private void OnEnemySeenByDriver(Vector2 position)
		{
			OnPriorityMoveTargetSeenByDriver?.Invoke();
		}
	}
}