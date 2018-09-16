using UnityEngine;

namespace Game.Tank.Stimulus
{
	public class DriverStimulus : Stimulus
	{
		protected override void OnStimulusTriggered(Collider2D other)
		{
			Debug.Log("Driver saw something");
		}
	}
}