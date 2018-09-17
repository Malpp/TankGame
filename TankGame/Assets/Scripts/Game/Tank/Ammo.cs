using System.Collections;
using UnityEngine;

namespace Game.Tank
{
	public class Ammo : MonoBehaviour
	{
		[SerializeField] private int ammo;
		[SerializeField] private float reloadTime;

		private bool reloading = false;

		public bool CanShoot => ammo > 0 && !reloading;

		public void LoadAmmo()
		{
			ammo--;
			StartCoroutine(ReloadAmmoCoroutine());
		}

		public void Refill(int nbAmmo)
		{
			ammo += nbAmmo;
		}

		private IEnumerator ReloadAmmoCoroutine()
		{
			reloading = true;
			yield return new WaitForSeconds(reloadTime);
			reloading = false;
		}
	}
}