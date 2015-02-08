using UnityEngine;
using System.Collections;

public class TestLevel : BaseSpawnScript {
	public GameObject basicEnemy;
	public GameObject zigZagEnemy;
	public GameObject boss;

	public Transform top;
	public Transform upperLeft;
	public Transform upperRight;
	public Transform left;
	public Transform right;
	public Transform bottom;

	void Start () {
		AddFormation (new RectFormationBuilder (zigZagEnemy, left, 1)
		              .WithLength (3)
		              .WithWidth (4)
		              .WithHorizontalSeparation (1)
		              .WithVerticalSeparation (2));
		AddFormation (new RectFormationBuilder (zigZagEnemy, right, 1)
		              .WithLength (3)
		              .WithWidth (4)
		              .WithHorizontalSeparation (1)
		              .WithVerticalSeparation (2));
		AddFormation (new RectFormationBuilder (basicEnemy, upperLeft, 5)
		              .WithLength (2)
		              .WithWidth (2)
		              .WithHorizontalSeparation (1)
		              .WithVerticalSeparation (1));
		AddFormation (new RectFormationBuilder (basicEnemy, upperRight, 5)
		              .WithLength (2)
		              .WithWidth (2)
		              .WithHorizontalSeparation (1)
		              .WithVerticalSeparation (1));
		AddFormation (new LineFormationBuilder (basicEnemy, upperLeft, 9)
		              .WithLength (2)
		              .WithSeparation (1));
		AddFormation (new LineFormationBuilder (basicEnemy, upperRight, 9)
		              .WithLength (2)
		              .WithSeparation (1));
		AddFormation (new LineFormationBuilder (zigZagEnemy, bottom, 9)
		              .WithLength (5)
		              .WithSeparation (1.5));
		AddSpawn (boss, top, 15);
	}
}
