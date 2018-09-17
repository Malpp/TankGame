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
		private bool someoneWon;

		public event Delegates.EventHandlerT<int> OnScoreChanged;
		public event Delegates.EventHandler OnPlayerWin;
		public event Delegates.EventHandler OnAiWin;

		private void OnEnable()
		{
			player = GameObject.FindWithTag(Tags.Player);
			enemy = GameObject.FindWithTag(Tags.Enemy);
			scoreCoroutine = StartCoroutine(AddScoreCoroutine());
		}

		private void FixedUpdate()
		{
			if (someoneWon)
				return;

			if (player == null)
			{
				SomeoneWon();
				OnAiWin?.Invoke();
			}

			if (score >= 60 || enemy == null)
			{
				SomeoneWon();
				OnPlayerWin?.Invoke();
				if (enemy != null)
					enemy.GetComponentInChildren<Health>().Die();
			}
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

		private void SomeoneWon()
		{
			someoneWon = true;
			StopCoroutine(scoreCoroutine);
		}
	}
}