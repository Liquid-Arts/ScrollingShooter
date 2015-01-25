using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int health;
	public Slider slider;

	void Awake() {
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
