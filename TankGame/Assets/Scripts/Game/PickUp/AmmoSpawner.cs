using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
	private List<Transform> spawnerList;
	[SerializeField] private GameObject ammo;
	private int indexSpawner = 0;
	private int nbOfAmmoPack = 0;
	[SerializeField] private float timeBufferInSecond = 3f;
	private float timeFrame = 0;
	public int NbOfAmmoPack
	{
		get { return nbOfAmmoPack; }
		set { nbOfAmmoPack = value; }
	}
	private void Awake()
	{
		spawnerList = new List<Transform>();
		foreach (Transform child in transform)
		{
			spawnerList.Add(child);
		}
	}

	// Use this for initialization
	void Start () {
		SpawnAmmoPack(spawnerList[indexSpawner]);
	}
	
	// Update is called once per frame
	void Update () {
		Spawn();
	}

	private void Spawn()
	{
		if (Time.time - timeFrame > timeBufferInSecond && nbOfAmmoPack < 2)
		{
			if (spawnerList[indexSpawner].childCount == 0)
			{
				SpawnAmmoPack(spawnerList[indexSpawner]);
				timeFrame = Time.time;
			}
			else
			{
				indexSpawner++;
				if (indexSpawner == spawnerList.Count)
					indexSpawner = 0;
			}
		}
	}
	private void SpawnAmmoPack(Transform spawner)
	{
		indexSpawner++;
		nbOfAmmoPack++;
		Instantiate(ammo, spawner);
		if (indexSpawner == spawnerList.Count)
			indexSpawner = 0;
	}
}
