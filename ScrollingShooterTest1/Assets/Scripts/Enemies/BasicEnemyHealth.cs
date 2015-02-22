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
		UpdateScore ();
		Destroy (gameObject);
	}

	private void UpdateScore() {
		EnemyScore enemyScore = gameObject.GetComponent<EnemyScore> ();
		if (enemyScore != null) {
			int scoreValue = enemyScore.scoreValue;
			GameObject scoreUIText = GameObject.Find ("scoreUIText");
			if (scoreUIText != null) {
				scoreController scoreScript = (scoreController)scoreUIText.GetComponent (typeof(scoreController)); 
				if (scoreScript != null) {
					scoreScript.UpdateScore (scoreValue);
				}
			}
		}
	}
}
