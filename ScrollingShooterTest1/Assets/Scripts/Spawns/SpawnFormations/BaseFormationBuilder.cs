using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class BaseFormationBuilder {
	protected GameObject spawnObject;
	protected Vector3 startPosition;
	protected Quaternion rotation;
	protected float delaySeconds;

	protected BaseFormationBuilder(GameObject newSpawnObject, Transform newStartLocation, float newDelaySeconds)
	{
		spawnObject = newSpawnObject;
		startPosition = newStartLocation.position;
		rotation = newStartLocation.rotation;
		delaySeconds = newDelaySeconds;
	}

	public abstract Formation GetFormation();
}
