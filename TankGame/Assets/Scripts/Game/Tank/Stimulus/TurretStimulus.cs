using UnityEngine;

namespace Game.Tank.Stimulus
{
	public class TurretStimulus : Stimulus
	{
		protected override void OnStimulusTriggered(Collider2D other)
		{
			Debug.Log("Turret saw something");
		}
	}
}