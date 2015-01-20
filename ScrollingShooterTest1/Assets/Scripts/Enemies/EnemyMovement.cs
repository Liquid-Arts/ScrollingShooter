using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	Transform player;
	NavMeshAgent nav;
	public float speed;
	Vector3 enemyToPlayer;
	Rigidbody2D enemyRigidBody;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();
		enemyRigidBody = GetComponent<Rigidbody2D> ();
		
	}

	void Update ()
	{
		enemyToPlayer = player.position - transform.position;
		enemyToPlayer.z = 0f;
		enemyToPlayer = enemyToPlayer.normalized;

		enemyRigidBody.velocity = enemyToPlayer * speed;
	}

}
