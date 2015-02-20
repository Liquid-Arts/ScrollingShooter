using UnityEngine;
using System.Collections;

public class DestroyShotOnEnter : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Shot") {
			Destroy(other.gameObject);
		}
	}

	void OnCollisionEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy(other.gameObject);
		}
	}
}
