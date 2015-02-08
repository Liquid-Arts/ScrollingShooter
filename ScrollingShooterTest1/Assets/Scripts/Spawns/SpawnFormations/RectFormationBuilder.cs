using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RectFormationBuilder : BaseFormationBuilder {
	private int length;
	private int width;
	private float horizontalSeparation;
	private float verticalSeparation;

	public RectFormationBuilder(GameObject newObjectSpawn, Transform newStartPosition, float newDelaySeconds) : base(newObjectSpawn, newStartPosition, newDelaySeconds)
	{
		length = 2;
		width = 2;
		horizontalSeparation = 1;
		verticalSeparation = 1;
	}

	public RectFormationBuilder WithLength(int newLength)
	{
		length = newLength;
		return this;
	}

	public RectFormationBuilder WithWidth(int newWidth)
	{
		width = newWidth;
		return this;
	}

	public RectFormationBuilder WithHorizontalSeparation(double separation)
	{
		horizontalSeparation = (float) separation;
		return this;
	}

	public RectFormationBuilder WithVerticalSeparation(double separation)
	{
		verticalSeparation = (float) separation;
		return this;
	}

	public override Formation GetFormation()
	{
		List<Vector3> positions = new List<Vector3> ();

		for (int x = 0; x < length; x++) {
			float xOffset = horizontalSeparation * x;
			for (int y = 0; y < width; y++) {
				float yOffset = verticalSeparation * y;
				Vector3 currentPosition = startPosition + (rotation * new Vector3(xOffset, -yOffset, 0));
				positions.Add(currentPosition);
			}
		}

		return new Formation (spawnObject, positions, rotation, delaySeconds);
	}
}
