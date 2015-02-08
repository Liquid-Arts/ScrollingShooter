using UnityEngine;
using System.Collections;

public class LayoutTestLevel : BaseSpawnScript  {

	public GameObject basicEnemy;
	public GameObject zigZagEnemy;
	public GameObject boss;
	
	public Transform top;
	public Transform left;
	public Transform right;
	public Transform bottom;
	
	void Start () {
		AddFormation (new RectFormationBuilder (basicEnemy, left, 1)
		              .WithLength (3)
		              .WithWidth (1)
		              .WithHorizontalSeparation (1)
		              .WithVerticalSeparation (2));
		AddFormation (new RectFormationBuilder (basicEnemy, right, 1)
		              .WithLength (3)
		              .WithWidth (1)
		              .WithHorizontalSeparation (1)
		              .WithVerticalSeparation (2));
		AddFormation (new LineFormationBuilder (zigZagEnemy, bottom, 7)
		              .WithLength (5)
		              .WithSeparation (1.5));
		AddSpawn (boss, top, 10);
	}
}
