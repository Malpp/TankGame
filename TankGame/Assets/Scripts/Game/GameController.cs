using System.Collections;
using Game.Tank;
using Game.Utils;
using Game.Values;
using UnityEngine;

namespace Game
{
	public class GameController : MonoBehaviour
	{
		private int score;
		private GameObject player;
		private GameObject enemy;
		private Coroutine scoreCoroutine;

		public event Delegates.EventHandlerT<int> OnScoreChanged;
		public event Delegates.EventHandler OnPlayerWin;
		public event Delegates.EventHandler OnAIWin;

		private void OnEnable()
		{
			player = GameObject.FindWithTag(Tags.Player);
			enemy = GameObject.FindWithTag(Tags.Enemy);
			scoreCoroutine = StartCoroutine(AddScoreCoroutine());
		}

		private void FixedUpdate()
		{
			if (player == null)
			{
				StopCoroutine(scoreCoroutine);
				OnAIWin?.Invoke();
			}

			if (score < 60 && enemy != null) return;
			OnPlayerWin?.Invoke();
			enemy.GetComponentInChildren<Health>().Die();
			StopCoroutine(scoreCoroutine);
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