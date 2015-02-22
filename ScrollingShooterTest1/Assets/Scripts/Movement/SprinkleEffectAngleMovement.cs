using UnityEngine;
using System.Collections;

public class SprinkleEffectAngleMovement : MonoBehaviour {
	public GameObject gameObject;
	public float angle;
	public float speed;
	public bool startClockwise;

	private bool isClockwise;

	void Start () {
		isClockwise = startClockwise;
		Rotate ();
	}

	private void Rotate () {
		AngularMovementUtil.MoveAngle (gameObject, angle, isClockwise, speed, Rotate);
		isClockwise = !isClockwise;
	}
}
