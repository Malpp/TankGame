using UnityEngine;

namespace Game.Tank.Stimulus
{
	public delegate void StimulusEventHandler(Collider2D other);

	public class Stimulus : MonoBehaviour
	{
		public event StimulusEventHandler OnStimulusActivated;

		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.isTrigger)
				return;
			Debug.Log("Hello");
			if (OnStimulusActivated != null)
				OnStimulusActivated.Invoke(other);
		}
	}
}