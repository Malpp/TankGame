using Game.Tank;
using Game.Values;
using UnityEngine;

namespace Game.PickUp
{
	public class AmmoPickup : MonoBehaviour
	{
		[SerializeField] private int nbAmmoToRefill = 5;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!other.CompareTag(Tags.Tank)) return;
			other.transform.parent.GetComponentInChildren<Ammo>().Refill(nbAmmoToRefill);
			Destroy(gameObject);
		}
	}
}