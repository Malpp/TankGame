using Game.Tank.Stimulus;
using UnityEngine;

namespace Game.Pandemonium.Feature
{
	public class FeatureEnemy : MonoBehaviour
	{
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
			//driverStimulus.OnStimulusActivated += OnEnemySeen;
		}

		private void OnEnemySeen(GameObject enemyGameObject)
		{
			
		}
	}
}