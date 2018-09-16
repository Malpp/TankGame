using UnityEngine;

namespace Game.Tank.Stimulus
{
	public delegate void StimulusEventHandler(Collider2D other);

	public abstract class Stimulus : MonoBehaviour
	{
		[SerializeField] private Transform lastTransformSeen;
		
		public event StimulusEventHandler OnStimulusActivated;

		private void OnTriggerStay2D(Collider2D other)
		{
			if(other.isTrigger)
				return;
			lastTransformSeen = other.transform;
			OnStimulusActivated?.Invoke(other);
			OnStimulusTriggered(other);
		}

		protected virtual void OnStimulusTriggered(Collider2D other)
		{
		}
	}
}