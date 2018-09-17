using Game.Tank;
using UnityEngine;

namespace Game.Pandemonium.Feature
{
	public delegate void TankOutOfAmmoEventHandler(bool isOutOfAmmo);
	
	public class AmmoReservesSensor : MonoBehaviour
	{
		public event TankOutOfAmmoEventHandler OnTankOutOfAmmo;
		
		private Ammo ammo;
		
		private void Awake()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			ammo = transform.root.GetComponentInChildren<Ammo>();
		}

		private void Update()
		{
			OnTankOutOfAmmo?.Invoke(!ammo.CanShoot);
		}
	}
}