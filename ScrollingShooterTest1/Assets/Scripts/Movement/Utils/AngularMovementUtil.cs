using UnityEngine;
using System.Collections;

public class AngularMovementUtil {
	private static readonly float speedMultiplier = 3;

	public static void MoveAngle(GameObject gameObject, float angle, bool rotateClockwise, float speed, System.Action onCompleteCallback) {
		float finalAngle = CalculateAngle (gameObject, angle, rotateClockwise);
		float time = CalculateTime (speed, angle);
		LTDescr tweenDescr = LeanTween.rotateZ (gameObject, finalAngle, time);
		if (onCompleteCallback != null) {
			tweenDescr.setOnComplete(onCompleteCallback);
		}
	}

	private static float CalculateAngle(GameObject gameObject, float angle, bool rotateClockwise) {
		float finalAngle = gameObject.transform.rotation.eulerAngles.z;
		if (rotateClockwise) {
			finalAngle -= angle;
		} else {
			finalAngle += angle;
		}

		return finalAngle;
	}
	
	private static float CalculateTime(float speed, float angle) {
		return angle / (speed * speedMultiplier);
	}
}
