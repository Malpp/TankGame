using UnityEngine;

namespace Game.Tank
{
	public class Cannon : MonoBehaviour
	{
		[SerializeField] private GameObject cannonShotPrefab;
		private Ammo ammo;

		private void Awake()
		{
			ammo = transform.parent.GetComponentInChildren<Ammo>();
		}

		public void Shoot()
		{
			if (ammo.CanShoot)
			{
				ammo.LoadAmmo();
				FireCannon();
			}
		}

		private void FireCannon()
		{
			Instantiate(cannonShotPrefab, transform.position, transform.rotation);
		}
	}
}