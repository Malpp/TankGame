using UnityEngine;

namespace Game.Tank
{
	public class Health : MonoBehaviour
	{
		[SerializeField] private int health;
		[SerializeField] private GameObject explosionPrefab;

		public void TakeHit()
		{
			health--;

			if (health < 1)
			{
				Die();
			}
		}

		internal void Die()
		{
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(transform.root.gameObject);
		}
	}
}