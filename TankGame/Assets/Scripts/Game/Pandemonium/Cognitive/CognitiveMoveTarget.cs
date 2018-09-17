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
		private FeatureAmmoContainer featureAmmoContainer;
		private bool isOutOfAmmo = false;

		private Vector2 lastSeenTargetPosition;

		private void Awake()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			featureEnemy = GetComponent<FeatureEnemy>();
			featureAmmoContainer = GetComponent<FeatureAmmoContainer>();
		}

		private void OnEnable()
		{
			featureEnemy.OnEnemySeenByDriver += OnEnemySeen;
			featureEnemy.OnEnemySeenByDriver += OnEnemySeenByDriver;
			featureEnemy.OnEnemySeenByCommander += OnEnemySeen;
			featureEnemy.OnEnemySeenByTurret += OnEnemySeen;
			featureAmmoContainer.OnAmmoSeenByDriver += OnAmmoContainerSeen;
			featureAmmoContainer.OnAmmoSeenByDriver += OnAmmoContainerSeenByDriver;
			featureAmmoContainer.OnAmmoSeenByCommander += OnAmmoContainerSeen;
			featureAmmoContainer.OnAmmoSeenByTurret += OnAmmoContainerSeen;
		}

		private void OnEnemySeen(Vector2 position)
		{
			if (isOutOfAmmo) return;
			lastSeenTargetPosition = position;
			OnPriorityMoveTargetSelected?.Invoke(lastSeenTargetPosition);
		}

		private void OnAmmoContainerSeen(Vector2 position)
		{
			if (!isOutOfAmmo) return;
			lastSeenTargetPosition = position;
			OnPriorityMoveTargetSelected?.Invoke(lastSeenTargetPosition);
		}

		private void OnEnemySeenByDriver(Vector2 position)
		{
			if (!isOutOfAmmo)
				OnPriorityMoveTargetSeenByDriver?.Invoke();
		}

		private void OnAmmoContainerSeenByDriver(Vector2 position)
		{
			if (isOutOfAmmo)
				OnPriorityMoveTargetSeenByDriver?.Invoke();
		}
	}
}