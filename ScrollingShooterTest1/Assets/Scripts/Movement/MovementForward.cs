using UnityEngine;
using System.Collections;

public class MovementForward : MonoBehaviour 
{
	public float speed;
	
	void Start ()
	{
		rigidbody2D.velocity = transform.up * speed;
		
	}
	
}
