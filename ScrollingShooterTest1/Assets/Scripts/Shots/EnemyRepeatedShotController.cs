using UnityEngine;
using System.Collections;

public class EnemyRepeatedShotController : MonoBehaviour {
	public Transform shotSpawnPoint;
	public GameObject shot;
	public float fireRate;
	public float delay;

	private float nextFire = 0f;

	void Start () {
		nextFire = Time.time + delay;
	}

	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawnPoint.position, shotSpawnPoint.rotation);
		}
	}
}
