using UnityEngine;

namespace Game.Tank.Stimulus
{
	public class CommanderStimulus : Stimulus
	{
		protected override void OnStimulusTriggered(Collider2D other)
		{
			Debug.Log("Commander saw something");
		}
	}
}