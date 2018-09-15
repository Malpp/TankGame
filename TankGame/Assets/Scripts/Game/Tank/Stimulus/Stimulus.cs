using UnityEngine;

namespace Game.Tank.Stimulus
{
	public delegate void StimulusEventHandler(Collision2D other);

	public class Stimulus : MonoBehaviour
	{
		public event StimulusEventHandler OnStimulusActivated;

		private void OnCollisionStay2D(Collision2D other)
		{
			OnStimulusActivated?.Invoke(other);
		}
	}
}