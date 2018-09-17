using System.Collections;
using Game.Utils;
using UnityEngine;

namespace Game
{
	public class GameController : MonoBehaviour
	{
		private int score;

		public event Delegates.EventHandlerT<int> OnScoreChanged;

		private void OnEnable()
		{
			StartCoroutine(AddScoreCoroutine());
		}

		private IEnumerator AddScoreCoroutine()
		{
			while (true)
			{
				yield return new WaitForSecondsRealtime(1f);
				score++;
				OnScoreChanged?.Invoke(score);
			}
		}
	}
}