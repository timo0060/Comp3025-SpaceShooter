using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed, tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;	//Since shotSpawn is a child object of Player, it's
								//Transform will update with the Player's Transform,
								//providing a simple access-point for the current
								//Player's Vector3 Transform
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;

	/**
	 * Create an instance of the shot (Instance of the Bolt prefab)
	 * object.
	 */
	public void FireShot() {
		GameObject clone = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject as GameObject;
	}// end FireShot method

	/**
	 * The Update method is called with each Scene (Frame) update
	 */
	void Update() {
		if( Input.GetButton("Fire1") && Time.time > nextFire ) {
			nextFire = Time.time + fireRate;
			FireShot();
		}// end if statement
	}// end Update method

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3 (
			Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}// end FixedUpdate method
}//end PlayerController class