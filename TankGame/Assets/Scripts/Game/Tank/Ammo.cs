using UnityEngine;

namespace Game.Tank
{
	public class Ammo : MonoBehaviour
	{
		[SerializeField]
		private int ammo;

		public bool CanShoot => ammo > 0;

		public void LoadAmmo()
		{
			ammo--;
		}
	}
}