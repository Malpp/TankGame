using System.Collections;
using System.Collections.Generic;
using Game.Tank;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
	private const string SpawnerGameObjectName = "AmmoSpawner";
	[SerializeField]
	private int nbAmmoToRefill = 5;

	private AmmoSpawner ammoSpawner;

	private void Awake()
	{
		ammoSpawner = GameObject.Find(SpawnerGameObjectName).GetComponentInChildren<AmmoSpawner>();
	}

	public void RefillTank(Ammo tankAmmo)
	{
		tankAmmo.Refill(nbAmmoToRefill);
		ammoSpawner.NbOfAmmoPack--;
	}
}
