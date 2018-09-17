using System.Collections;
using UnityEngine;

namespace Game.PickUp
{
	public class AmmoSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject ammoPickupPrefab;
		[SerializeField] private float spawnDelay;
		[SerializeField] private float spawnDelayRandomness;

		private void OnEnable()
		{
			StartCoroutine(SpawnAmmoPack());
		}

		private IEnumerator SpawnAmmoPack()
		{
			yield return new WaitForSeconds(spawnDelay + Random.Range(-spawnDelayRandomness, spawnDelayRandomness));
			if (transform.childCount == 0)
				Instantiate(ammoPickupPrefab, transform);
		}
	}
}