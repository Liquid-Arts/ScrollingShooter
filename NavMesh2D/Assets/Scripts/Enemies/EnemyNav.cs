﻿using UnityEngine;
using System.Collections;

public class EnemyNav : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();
	}



	void Update()
	{
		nav.SetDestination (player.position);
	}
}
