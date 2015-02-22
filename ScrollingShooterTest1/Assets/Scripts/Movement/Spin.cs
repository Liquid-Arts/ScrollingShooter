using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	public float speed;

	private static readonly float speedMultiplier = 10;

	void Update ()
	{
		transform.Rotate(Vector3.forward, speed * speedMultiplier * Time.deltaTime);
	}
}
