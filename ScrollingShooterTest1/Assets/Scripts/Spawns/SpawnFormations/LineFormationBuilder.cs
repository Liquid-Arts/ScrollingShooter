using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineFormationBuilder : BaseFormationBuilder {
	private int lineLength;
	private float separation;

	public LineFormationBuilder(GameObject newObjectSpawn, Transform newStartPosition, float newDelaySeconds) : base(newObjectSpawn, newStartPosition, newDelaySeconds)
	{
		lineLength = 3;
		separation = 1;
	}

	public LineFormationBuilder WithLength(int newLineLength)
	{
		lineLength = newLineLength;
		return this;
	}

	public LineFormationBuilder WithSeparation(double units)
	{
		separation = (float) units;
		return this;
	}

	public override Formation GetFormation()
	{
		List<Vector3> positions = new List<Vector3> ();
		Vector3 currentPosition = startPosition;
		for (int i = 0; i < lineLength; i++) {
			positions.Add(currentPosition);
			currentPosition += (rotation * new Vector3(0, -separation, 0));
		}

		return new Formation (spawnObject, positions, rotation, delaySeconds);
	}
}
