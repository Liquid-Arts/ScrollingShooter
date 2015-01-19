using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float xmin, xmax, ymin, ymax;

	public float fireRate;
	private float nextFire = 0f;
	public GameObject shot;
	public Transform shotSpawn;

	Rigidbody2D playerRigidBody;
	int floorMask;
	float camRayLength = 600f;
	Vector3 movement;

	void Awake ()
	{
		floorMask = LayerMask.GetMask ("Floor");
		playerRigidBody = GetComponent<Rigidbody2D> ();
	}


	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}


	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Turning ();

		Move (h, v);

	}


	void Move (float h, float v)
	{
		movement.Set (h, v, 0f);

		movement = movement.normalized * speed;
		
		playerRigidBody.velocity = movement;

		playerRigidBody.position = new Vector3 
		(
				Mathf.Clamp (playerRigidBody.position.x, xmin, xmax),
				Mathf.Clamp (playerRigidBody.position.y, ymin, ymax),
				-2f
		);
	}


	void Turning ()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask) )
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.z = 0f;


			float angle = Mathf.Atan2(playerToMouse.y, playerToMouse.x) *Mathf.Rad2Deg - 90f;

			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		}

	}
}
