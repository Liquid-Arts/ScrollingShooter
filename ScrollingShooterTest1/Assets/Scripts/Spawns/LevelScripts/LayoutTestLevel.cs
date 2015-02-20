using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LayoutTestLevel : BaseSpawnScript  {

	public GameObject basicEnemy;
	public GameObject zigZagEnemy;
	public GameObject boss;
	public GameObject player;
	public GameObject pauseText;
	
	public Transform top;
	public Transform left;
	public Transform right;
	public Transform bottom;

	bool isPause = false;
	
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

	void Update (){

		if (!player){
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetKeyDown ("escape") && !isPause) {
			Time.timeScale=0.0F;
			isPause=true;
			pauseText.SetActive(true);
			player.GetComponent<ShootController>().enabled=false;
		}
		else if(Input.GetKeyDown ("escape") && isPause){
			Time.timeScale=1.0F;
			isPause=false;
			pauseText.SetActive(false);
			player.GetComponent<ShootController>().enabled=true;
		}

	}
}
