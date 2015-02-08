using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurveMovementUtil {
	private static readonly float arcBroad = 0.9f;
	
	public static void MoveOnCurve(GameObject gameObject, Transform startPosition, float speed, float arcWidth, float arcLength, bool curveRight, System.Action onCompleteCallback) {
		List<Vector3> points = GetCurvePoints (startPosition, arcWidth, arcLength, curveRight);
		float time = PathLength (points) / speed;
		LTDescr tweenDescr = LeanTween.move (gameObject, points.ToArray (), time);
		if (onCompleteCallback != null)
		{
			tweenDescr.setOnComplete(onCompleteCallback);
		}
	}
	
	private static List<Vector3> GetCurvePoints(Transform startPoint, float arcWidth, float arcLength, bool rightCurve) {
		List<Vector3> points = new List<Vector3> ();
		
		points.Add (startPoint.position);
		
		float xArcPoint = arcWidth * arcBroad;
		if (!rightCurve)
		{
			xArcPoint *= -1;
		}
		Vector3 control1 = startPoint.position + (startPoint.rotation * new Vector3 (xArcPoint, arcLength/2 * arcBroad, 0));
		points.Add (control1);
		
		Vector3 control2 = startPoint.position + (startPoint.rotation * new Vector3 (xArcPoint, arcLength/2 + (arcLength/2 * (1 - arcBroad)), 0));
		points.Add (control2);
		
		Vector3 endPoint = startPoint.position + (startPoint.rotation * new Vector3 (0, arcLength, 0));
		points.Add (endPoint);
		return points;
	}
	
	// Warning: This method is a very broad approximation of the curve length. In fact it's not even close, but it's good enough
	private static float PathLength(List<Vector3> points) {
		float length = 0;
		for (int i = 0; i < points.Count - 1; i++)
		{
			Vector3 firstPoint = points [i];
			Vector3 secondPoint = points[i+1];
			length += Mathf.Sqrt(Mathf.Pow(secondPoint.y - firstPoint.y, 2) + Mathf.Pow(secondPoint.x - firstPoint.x, 2));
		}
		return length;
	}
}
