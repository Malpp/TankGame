using Game.Pandemonium.Cognitive;
using UnityEngine;

namespace Game.Pandemonium
{
	public class Decision : MonoBehaviour
	{
		private Transform rootTransform;
		private CognitiveMoveTarget cognitiveMoveTarget;

		private Vector2 lastSeenEnemyPosition;

		private void Awake()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			rootTransform = transform.root;
			cognitiveMoveTarget = rootTransform.GetComponentInChildren<CognitiveMoveTarget>();
		}
	}
}