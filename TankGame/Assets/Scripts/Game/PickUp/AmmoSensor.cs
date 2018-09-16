using System.Collections;
using System.Collections.Generic;
using Game.Tank;
using UnityEngine;

public class AmmoSensor : MonoBehaviour
{
	private const string ColliderName = "Body";

	private void OnCollisionEnter2D(Collision2D other)
	{
		AmmoController ammoController = transform.parent.GetComponentInChildren<AmmoController>();
		Ammo tankAmmo = other.transform?.GetComponentInChildren<Ammo>();
		if (other.collider.name == ColliderName && tankAmmo != null)
		{
			ammoController.RefillTank(tankAmmo);
			Destroy(transform.parent.gameObject);
		}
	}

}
