using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZigZagMovement : MonoBehaviour {
	public float speed;
	public float length;
	public float arcWidth;
	public bool curveOnRight;
	private bool isCurvingRight;

	void Start ()
	{
		isCurvingRight = curveOnRight;
		MoveOnCurve ();
	}

	private void MoveOnCurve() {
		CurveMovementUtil.MoveOnCurve (gameObject, this.transform, speed, arcWidth, length, isCurvingRight, MoveOnCurve);
		isCurvingRight = !isCurvingRight;
	}
}
