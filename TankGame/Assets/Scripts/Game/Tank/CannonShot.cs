using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour
{
	[SerializeField] private float cannonShotForce;
	[SerializeField] private float secondsUntilSelfdestruct;
	private Rigidbody2D rigidbody;

	private void Awake()
	{
		rigidbody = GetComponentInParent<Rigidbody2D>();
	}

	private void OnEnable()
	{
		rigidbody.AddRelativeForce(Vector2.up * cannonShotForce);
		StartCoroutine(StartDestroyCoroutine());
	}

	private IEnumerator StartDestroyCoroutine()
	{
		yield return new WaitForSeconds(secondsUntilSelfdestruct);
		Destroy(transform.parent.gameObject);
	}
}