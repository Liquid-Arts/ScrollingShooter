using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			/*col.gameObject.GetComponent<EnemyMovement>().enabled = false;*/
			Destroy(gameObject);
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
