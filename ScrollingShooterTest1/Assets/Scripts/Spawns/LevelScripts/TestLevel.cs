using UnityEngine;
using System.Collections;

public class TestLevel : BaseSpawnScript {
	public GameObject enemy;
	public GameObject boss;

	public Transform upperLeft;
	public Transform upperRight;
	public Transform top;
	public Transform bottom;

	void Start () {
		AddFormation (new LineFormationBuilder (enemy, upperLeft, 1)
		              .WithLength (2)
		              .WithSeparation (1)
		              .GetFormation());
		AddFormation (new LineFormationBuilder (enemy, upperRight, 1)
		              .WithLength (2)
		              .WithSeparation (1)
		              .GetFormation());
		AddFormation (new LineFormationBuilder (enemy, bottom, 4)
		              .WithLength (5)
		              .WithSeparation (1.5)
		              .GetFormation());
		AddSpawn (boss, top, 7);
	}
}
