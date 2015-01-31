using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Formation {
	private List<Spawn> spawns;
	public List<Spawn> Spawns { get { return spawns; } }

	public Formation(GameObject objectSpawn, List<Vector3> spawnPositions, Quaternion spawnRotation, float delaySeconds) {
		spawns = new List<Spawn> ();
		foreach(Vector3 position in spawnPositions)
		{
			spawns.Add(Spawn.Of(objectSpawn, position, spawnRotation, delaySeconds));
		}
	}
}
