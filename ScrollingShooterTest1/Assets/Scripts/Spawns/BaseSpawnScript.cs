using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class BaseSpawnScript : MonoBehaviour {
	private Queue<Spawn> spawns;

	public BaseSpawnScript()
	{
		spawns = new Queue<Spawn>();
	}

	public void AddSpawn(GameObject spawnObject, Transform position, double delayInSeconds)
	{
		spawns.Enqueue (Spawn.Of (spawnObject, position, (float) delayInSeconds));
	}

	public void AddFormation(Formation formation)
	{
		foreach (Spawn spawn in formation.Spawns)
		{
			spawns.Enqueue(spawn);
		}
	}

	public void AddFormation(BaseFormationBuilder formationBuilder)
	{
		foreach (Spawn spawn in formationBuilder.GetFormation().Spawns)
		{
			spawns.Enqueue(spawn);
		}
	}

	public Spawn GetNextSpawn() {
		if (spawns.Count > 0) {
			return spawns.Dequeue();
		} else {
			return null;
		}
	}
}
