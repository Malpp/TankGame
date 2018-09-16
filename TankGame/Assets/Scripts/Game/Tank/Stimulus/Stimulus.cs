using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Tank.Stimulus
{
	public delegate void StimulusEventHandler(Collider2D other);

	public abstract class Stimulus : MonoBehaviour
	{
		[SerializeField] private Transform lastTransformSeen;

		private List<Collider2D> thingsStimulated = new List<Collider2D>();

		public event StimulusEventHandler OnStimulusActivated;
		public event StimulusEventHandler OnStimulusEmpty;
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.isTrigger)
				return;
			thingsStimulated.Add(other);
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			thingsStimulated.Remove(other);
		}

		private void FixedUpdate()
		{
			if (thingsStimulated.Count == 0)
			{
				OnStimulusEmpty?.Invoke(null);
				return;
			}
			
			foreach (var other in thingsStimulated)
			{
				lastTransformSeen = other.transform;
				OnStimulusActivated?.Invoke(other);
				OnStimulusTriggered(other);
			}
		}

		protected virtual void OnStimulusTriggered(Collider2D other)
		{
		}
	}
}