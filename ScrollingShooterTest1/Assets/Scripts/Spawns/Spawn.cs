using UnityEngine;
using System.Collections;

public class Spawn {
	private GameObject spawnObject;
	private Vector3 position;
	private Quaternion rotation;
	private float delayInSeconds;

	public GameObject SpawnObject { get {return spawnObject; } }
	public Vector3 Position { get {return position; } }
	public Quaternion Rotation { get {return rotation; } }
	public float DelayInSeconds  { get {return delayInSeconds; } }

	private Spawn(GameObject newSpawn, Vector3 newPosition, Quaternion newRotation, float newDelayInSeconds)
	{
		this.spawnObject = newSpawn;
		this.position = newPosition;
		this.rotation = newRotation;
		this.delayInSeconds = newDelayInSeconds;
	}

	public static Spawn Of(GameObject newSpawn, Transform newTransform, float delayInSeconds)
	{
		return new Spawn (newSpawn, newTransform.position, newTransform.rotation, delayInSeconds);
	}

	public static Spawn Of(GameObject newSpawn, Vector3 newPosition, Quaternion newRotation, float newDelayInSeconds)
	{
		return new Spawn (newSpawn, newPosition, newRotation, newDelayInSeconds);
	}
}
