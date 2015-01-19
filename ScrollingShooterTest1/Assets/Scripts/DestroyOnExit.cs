using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour 
{
	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
}
