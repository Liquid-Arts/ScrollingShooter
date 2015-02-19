using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreController : MonoBehaviour {

	int counter = 0;
	public Text scoreText;

	void Start () {
		scoreText.text = "Score: " + counter.ToString();
	}

	public void UpdateScore(int scoreValue){
		counter += scoreValue;
		scoreText.text = "Score: " + counter.ToString();
	}
}
