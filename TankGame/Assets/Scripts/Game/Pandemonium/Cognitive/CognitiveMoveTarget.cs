﻿using Game.Pandemonium.Feature;
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
		private AmmoSensor ammoSensor;
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
			ammoSensor = GetComponent<AmmoSensor>();
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
			ammoSensor.OnTankOutOfAmmo += OnTankOutOfAmmo;
		}

		private void OnTankOutOfAmmo(bool tankIsOutOfAmmo)
		{
			isOutOfAmmo = tankIsOutOfAmmo;
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