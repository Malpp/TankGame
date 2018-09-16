using System.Collections.Generic;
using Game.Pandemonium.Feature;
using UnityEngine;

namespace Game.Pandemonium.Cognitive
{
	public delegate void TopPriorityMoveTargetEventHandler(Vector2 position);
	
	public class CognitiveMoveTarget : MonoBehaviour
	{
		public event TopPriorityMoveTargetEventHandler OnPriorityMoveTargetSelected;
		
		private Transform rootTransform;
		private FeatureEnemy featureEnemy;

		private Vector2 lastSeenEnemyPosition;

		private void Awake()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			rootTransform = transform.root;
			featureEnemy = GetComponent<FeatureEnemy>();
		}

		private void OnEnable()
		{
			featureEnemy.OnEnemySeen += OnEnemySeen;
		}

		private void OnEnemySeen(Vector2 position)
		{
			lastSeenEnemyPosition = position;
			OnPriorityMoveTargetSelected?.Invoke(lastSeenEnemyPosition);
		}
	}
}