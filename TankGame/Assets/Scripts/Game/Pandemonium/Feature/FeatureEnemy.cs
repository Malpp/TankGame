using Game.Tank.Stimulus;
using Game.Values;
using UnityEngine;

namespace Game.Pandemonium.Feature
{
	public delegate void FeatureEnemySeenByDriverEventHandler(Vector2 enemyPosition);

	public delegate void FeatureEnemySeenByCommanderEventHandler(Vector2 enemyPosition);

	public delegate void FeatureEnemySeenByTurretEventHandler(Vector2 enemyPosition);
	
	public class FeatureEnemy : MonoBehaviour
	{
		public event FeatureEnemySeenByDriverEventHandler OnEnemySeenByDriver;
		public event FeatureEnemySeenByCommanderEventHandler OnEnemySeenByCommander;
		public event FeatureEnemySeenByTurretEventHandler OnEnemySeenByTurret;
		
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
			if(ValidateGameObjectIsEnemy(otherCollision2D))
				OnEnemySeenByDriver?.Invoke(otherCollision2D.transform.root.position);
		}
		private void OnGameObjectSeenByCommander(Collider2D otherCollision2D)
		{
			if(ValidateGameObjectIsEnemy(otherCollision2D))
				OnEnemySeenByCommander?.Invoke(otherCollision2D.transform.root.position);
		}
		private void OnGameObjectSeenByTurret(Collider2D otherCollision2D)
		{
			if(ValidateGameObjectIsEnemy(otherCollision2D))
				OnEnemySeenByTurret?.Invoke(otherCollision2D.transform.root.position);
		}

		private static bool ValidateGameObjectIsEnemy(Collider2D otherCollision2D)
		{
			if (otherCollision2D.CompareTag(Tags.Tank))
				return true;
			return false;
		}
	}
}