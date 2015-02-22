using UnityEngine;
using System.Collections;

public class TargetPlayerMovement : MonoBehaviour {
	public float speed;

	void Start () {
		Transform player = GameObject.FindGameObjectWithTag ("Player").transform;

		Vector3 enemyToPlayer = player.position - transform.position;
		enemyToPlayer.z = 0f;
		enemyToPlayer = enemyToPlayer.normalized;

		rigidbody2D.velocity = enemyToPlayer * speed;
	}
}
