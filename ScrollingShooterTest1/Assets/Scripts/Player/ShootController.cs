using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShootController : MonoBehaviour {
	public List<GameObject> shots;
	public Text shotName;
	public Transform shotSpawn;
	public float switchRate = 0.2f;

	private int shotIndex;
	private GameObject currentShot;
	private float fireRate;
	private float nextFire = 0f;
	private float nextSwitch = 0f;

	void Awake()
	{
		changeShot ();
	}
	void Update ()
	{
		if (Input.GetButton ("Switch") && Time.time > nextSwitch) {
			nextSwitch = Time.time + switchRate;
			shotIndex = (shotIndex + 1) % shots.Count;
			changeShot ();
		}

		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(currentShot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	private void changeShot()
	{
		currentShot = shots [shotIndex];
		ShotAttributes shotAttr = currentShot.GetComponent<ShotAttributes> ();
		fireRate = shotAttr.fireRate;
		updateShotName (shotAttr.shotName);
	}

	private void updateShotName(string newShotName)
	{
		shotName.text = newShotName;
	}
}
