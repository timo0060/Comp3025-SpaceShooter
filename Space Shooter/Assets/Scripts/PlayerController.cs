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
    public MoveTouchPad movePad;
    public FireTouchPad firePad;

	/**
	 * Create an instance of the shot (Instance of the Bolt prefab)
	 * object.
	 */
	public void FireShot() {
//		GameObject clone = 
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
		GetComponent<AudioSource>().Play ();
	}// end of FireShot method

	/*
	 * The Update method in Unity is like Unreal Engine's Tick() method
	 * It gets called each time the frame is redrawn/updated.
	 */
	void Update() {
		//If a fire button was pressed and the firing cooldown time has elapsed then fire again
		if( firePad.GetCanFire() && Time.time > nextFire ) {
			nextFire = Time.time + fireRate;
			FireShot();
		}// end if statement
	}// end of Update method

	/*
	 * Same as Update, only for Fixed-Frame updates
	 */
	void FixedUpdate() {
        //float moveHorizontal = Input.GetAxis ("Horizontal");
        //float moveVertical = Input.GetAxis ("Vertical");

        Vector2 direction = movePad.GetDirection();

		Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);

		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3 (
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}// end FixedUpdate method
}//end PlayerController class