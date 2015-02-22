using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthDisplay : MonoBehaviour{
	public Slider slider;
	
	public void Setup(float health) {	
		// For spawned instances where the slider can't be set directly
		if (slider == null) {
			slider = GameObject.Find ("UICanvas").GetComponentInChildren<Slider> ();
		}
		slider.maxValue = health;
		slider.value = health;
		showHealthSlider (true);
	}

	public void OnDamageTaken(int damage)
	{
		slider.value -= damage;
	}
	
	public void OnDeath() {
		showHealthSlider (false);
	}
	
	private void showHealthSlider(bool show) {
		float newAlpha = show ? 1f : 0f;
		slider.GetComponent<CanvasGroup> ().alpha = newAlpha;
	}
}
