using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealth : MonoBehaviour {
	public int health;

	private EnemyHealthDisplay healthDisplay;

	void Start() {
		healthDisplay = GetComponent<EnemyHealthDisplay> ();
		if (healthDisplay != null) {
			healthDisplay.Setup (health);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Shot") {
			int damage = col.gameObject.GetComponent<ShotAttributes>().damage;
			TakeDamage(damage);
			Destroy(col.gameObject);
		}

		if (col.gameObject.tag == "Player") {
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
	}

	private void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0) {
			Die ();
		}
		if (healthDisplay != null) {
			healthDisplay.OnDamageTaken (damage);
		}
	}

	private void Die() {
		UpdateScore ();

		if (healthDisplay != null) {
			healthDisplay.OnDeath ();
		}

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
