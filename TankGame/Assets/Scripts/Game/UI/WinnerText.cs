using System;
using Game.Values;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	public class WinnerText : MonoBehaviour
	{
		private GameController gameController;
		private Text text;

		private void Awake()
		{
			gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();
			text = GetComponent<Text>();
		}

		private void OnEnable()
		{
			gameController.OnAiWin += OnAiWin;
			gameController.OnPlayerWin += OnPlayerWin;
		}

		private void OnPlayerWin()
		{
			SetVictoryText("Player");
		}

		private void OnAiWin()
		{
			SetVictoryText("AI");
		}

		private void SetVictoryText(String winner)
		{
			text.text = $"{winner} has won!";
			text.enabled = true;
		}
	}
}