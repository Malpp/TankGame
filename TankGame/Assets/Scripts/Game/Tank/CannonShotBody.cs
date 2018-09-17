using System.Collections;
using System.Collections.Generic;
using Game.Tank;
using Game.Values;
using UnityEngine;

public class CannonShotBody : MonoBehaviour
{
	private readonly Vector3 FAR_AWAY = new Vector3(15, 15);

	private void OnCollisionEnter2D(Collision2D other)
	{
		other.transform.GetComponentInChildren<Health>().TakeHit();
		StartCoroutine(StartOnHitDestroyCoroutine());
	}

	private IEnumerator StartOnHitDestroyCoroutine()
	{
		transform.parent.transform.position = FAR_AWAY;
		yield return new WaitForFixedUpdate();
		Destroy(transform.parent.gameObject);
	}
}