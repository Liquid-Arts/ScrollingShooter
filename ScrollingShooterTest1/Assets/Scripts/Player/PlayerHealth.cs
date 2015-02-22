using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
	{
		if (isHazard(col.gameObject)) {
			/*col.gameObject.GetComponent<EnemyMovement>().enabled = false;*/
			Destroy(gameObject);
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	private bool isHazard(GameObject gameObject) {
		return gameObject.tag == "Enemy" || gameObject.tag == "EnemyShot";
	}
}
