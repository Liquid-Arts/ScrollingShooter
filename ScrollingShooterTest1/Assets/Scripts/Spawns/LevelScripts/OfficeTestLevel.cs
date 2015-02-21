using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OfficeTestLevel : BaseSpawnScript  {

	public GameObject basicEnemy;
	public GameObject paperPlane;
	public GameObject zigZagEnemy;
	public GameObject boss;
	public GameObject player;
	public GameObject pauseText;

	public Transform left1;
	public Transform left2;
	public Transform left3;
	public Transform left4;
	public Transform left5;
	public Transform left6;
	public Transform left7;
	public Transform right1;
	public Transform right2;
	public Transform right3;
	public Transform right4;
	public Transform right5;
	public Transform right6;
	public Transform right7;


	bool isPause = false;
	
	void Start () {
		AddFormation (new RectFormationBuilder (paperPlane, left1, 5.2F)
		              .WithLength (1)
		              .WithWidth (4)
		              .WithHorizontalSeparation (1)
		              .WithVerticalSeparation (2));
		AddFormation (new RectFormationBuilder (paperPlane, right1, 5)
		              .WithLength (1)
		              .WithWidth (5)
		              .WithHorizontalSeparation (1)
		              .WithVerticalSeparation (2));
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
