using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour 
{
	void OnTriggerExit2D(Collider2D other) {
		Destroy(other.gameObject);
	}
}
