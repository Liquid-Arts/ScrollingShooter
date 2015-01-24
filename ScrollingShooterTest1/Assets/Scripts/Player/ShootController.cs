using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShootController : MonoBehaviour {
	public List<GameObject> shots;
	public Text shotName;
	public Transform shotSpawn;
	public float switchRate = 0.2f;

	private int shotIndex = 0;
	private GameObject currentShot;
	private float fireRate;
	private float nextFire = 0f;
	private float nextSwitch = 0f;

	void Awake()
	{
		ChangeShot ();
	}
	void Update ()
	{
		if (Input.GetButton ("Switch") && Time.time > nextSwitch) {
			nextSwitch = Time.time + switchRate;
			shotIndex = (shotIndex + 1) % shots.Count;
			ChangeShot ();
		}

		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(currentShot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	private void ChangeShot()
	{
		currentShot = shots [shotIndex];
		ShotAttributes shotAttr = currentShot.GetComponent<ShotAttributes> ();
		fireRate = shotAttr.fireRate;
		UpdateShotName (shotAttr.shotName);
	}

	private void UpdateShotName(string newShotName)
	{
		shotName.text = newShotName;
	}
}
