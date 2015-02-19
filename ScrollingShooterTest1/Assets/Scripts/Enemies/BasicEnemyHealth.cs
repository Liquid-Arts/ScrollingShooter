using UnityEngine;
using System.Collections;

public class BasicEnemyHealth : MonoBehaviour {

	public int health;

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Shot") {
			int damage = col.gameObject.GetComponent<ShotAttributes>().damage;
			TakeDamage(damage);
			Destroy(col.gameObject);
		}
	}

	private void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0) {
			Die ();
		}

	}
	
	private void Die() {
		int scoreValue = gameObject.GetComponent<EnemyScore> ().scoreValue;
		GameObject scoreUIText = GameObject.Find("scoreUIText");
		scoreController scoreScript = (scoreController) scoreUIText.GetComponent(typeof(scoreController)); 
		scoreScript.UpdateScore (scoreValue);
		Destroy (gameObject);
	}


}
