using UnityEngine;

namespace Game.Tank.Stimulus
{
	public class HearingStimulus : Stimulus
	{
		protected override void OnStimulusTriggered(Collider2D other)
		{
			Debug.Log("Heard something");
		}
	}
}