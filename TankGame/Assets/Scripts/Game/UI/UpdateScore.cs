using Game.Utils;
using Game.Values;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	public class UpdateScore : MonoBehaviour
	{
		private Text text;
		private GameController gameController;

		private void Awake()
		{
			text = GetComponent<Text>();
			gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();
		}

		private void OnEnable()
		{
			gameController.OnScoreChanged += UpdateScoreText;
		}

		private void UpdateScoreText(int value)
		{
			text.text = value.ToString();
		}
	}
}