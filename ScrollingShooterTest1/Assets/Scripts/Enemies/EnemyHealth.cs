using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int health;
	public Slider slider;

	void Awake() {
		// For spawned instances where the slider can't be set directly
		if (slider == null) {
			slider = GameObject.Find ("UICanvas").GetComponentInChildren<Slider> ();
		}
		slider.maxValue = health;
		slider.value = health;
		showHealthSlider (true);
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
		slider.value -= damage;
	}

	private void Die() {
		showHealthSlider (false);
		Destroy (gameObject);
	}

	private void showHealthSlider(bool show) {
		float newAlpha = show ? 1f : 0f;
		slider.GetComponent<CanvasGroup> ().alpha = newAlpha;
	}
}
