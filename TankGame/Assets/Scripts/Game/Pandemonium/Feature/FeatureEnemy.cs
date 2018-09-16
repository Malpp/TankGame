using Game.Tank.Stimulus;
using Game.Values;
using UnityEngine;

namespace Game.Pandemonium.Feature
{
	public delegate void FeatureEnemyEventHandler(Vector2 enemyPosition);
	
	public class FeatureEnemy : MonoBehaviour
	{
		public event FeatureEnemyEventHandler OnEnemySeen;
		
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
			driverStimulus.OnStimulusActivated += OnGameObjectSeen;
			commanderStimulus.OnStimulusActivated += OnGameObjectSeen;
			turretStimulus.OnStimulusActivated += OnGameObjectSeen;
		}

		private void OnGameObjectSeen(Collider2D otherCollision2D)
		{
			if (otherCollision2D.transform.root.CompareTag(Tags.Tank))
				OnEnemySeen?.Invoke(otherCollision2D.transform.root.position);
		}
	}
}