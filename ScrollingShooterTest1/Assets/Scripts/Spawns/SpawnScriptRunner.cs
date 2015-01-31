using UnityEngine;
using System.Collections;

public class SpawnScriptRunner : MonoBehaviour {

	private BaseSpawnScript script;
	private Spawn currentSpawn;

	void Start ()
	{
		script = GetComponent<BaseSpawnScript> ();
		currentSpawn = script.GetNextSpawn();
	}

	void Update ()
	{
		while (currentSpawn != null && Time.timeSinceLevelLoad > currentSpawn.DelayInSeconds) {
			Spawn (currentSpawn);
			currentSpawn = script.GetNextSpawn();
		}
	}

	private void Spawn(Spawn spawn) {
		Instantiate (spawn.SpawnObject, spawn.Position, spawn.Rotation);
	}
}
