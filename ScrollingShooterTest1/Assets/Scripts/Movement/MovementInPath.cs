using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementInPath : MonoBehaviour 
{
	public List<Transform> points;
	public float speed;
	private int currentIndex;
	private readonly float minThreshold = 0.1f;
	
	void Start ()
	{
		currentIndex = 0;
	}

	void LateUpdate ()
	{
		if (canMove ()) {
			MoveToPoint ();
			if (Vector3.Distance (CurrentPoint (), transform.position) < minThreshold) {
				currentIndex++;
			}
		}
	}
	
	private void MoveToPoint()
	{
		transform.position = Vector3.MoveTowards (transform.position, CurrentPoint (), speed * Time.deltaTime);
	}

	private bool canMove() {
		return currentIndex < points.Count;
	}

	private Vector3 CurrentPoint() {
		return points [currentIndex].position;
	}
}
