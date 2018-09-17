using Game.Tank.Stimulus;
using Game.Values;
using UnityEngine;

namespace Game.Pandemonium.Feature
{
	public delegate void FeatureAmmoSeenByDriverEventHandler(Vector2 ammoPosition);
	public delegate void FeatureAmmoSeenByCommanderEventHandler(Vector2 ammoPosition);
	public delegate void FeatureAmmoSeenByTurretEventHandler(Vector2 ammoPosition);

	public class FeatureAmmo : MonoBehaviour
	{
		public event FeatureAmmoSeenByDriverEventHandler OnAmmoSeenByDriver;
		public event FeatureAmmoSeenByCommanderEventHandler OnAmmoSeenByCommander;
		public event FeatureAmmoSeenByTurretEventHandler OnAmmoSeenByTurret;

		private Transform rootTransform;
		private DriverStimulus driverStimulus;
		private CommanderStimulus commanderStimulus;
		private TurretStimulus turretStimulus;

		private void Awake()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			rootTransform = transform.root;
			driverStimulus = rootTransform.GetComponentInChildren<DriverStimulus>();
			commanderStimulus = rootTransform.GetComponentInChildren<CommanderStimulus>();
			turretStimulus = rootTransform.GetComponentInChildren<TurretStimulus>();
		}

		private void OnEnable()
		{
			driverStimulus.OnStimulusActivated += OnGameObjectSeenByDriver;
			commanderStimulus.OnStimulusActivated += OnGameObjectSeenByCommander;
			turretStimulus.OnStimulusActivated += OnGameObjectSeenByTurret;
		}

		private void OnGameObjectSeenByDriver(Collider2D otherCollision2D)
		{
			if (ValidateGameObjectIsAmmo(otherCollision2D))
				OnAmmoSeenByDriver?.Invoke(otherCollision2D.transform.root.position);
		}

		private void OnGameObjectSeenByCommander(Collider2D otherCollision2D)
		{
			if (ValidateGameObjectIsAmmo(otherCollision2D))
				OnAmmoSeenByCommander?.Invoke(otherCollision2D.transform.root.position);
		}

		private void OnGameObjectSeenByTurret(Collider2D otherCollision2D)
		{
			if (ValidateGameObjectIsAmmo(otherCollision2D))
				OnAmmoSeenByTurret?.Invoke(otherCollision2D.transform.root.position);
		}

		private static bool ValidateGameObjectIsAmmo(Collider2D otherCollision2D)
		{
			if (otherCollision2D.CompareTag(Tags.Ammo))
				return true;
			return false;
		}
	}
}