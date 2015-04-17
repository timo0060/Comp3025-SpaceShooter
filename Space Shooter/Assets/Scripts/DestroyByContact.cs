using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	/*
	 * Start is like the constructor for Unity GameObjects.
	 * This is where properties should be initialized.
	 */
	void Start () {
		//Get a reference to the instance of the GameController object
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}

		//All is lost
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}//end of Start method

	/*
	 * Since Asteroids and Bolts act as Trigger colliders
	 * we use this event handler to handle when collission events
	 * are triggered
	 */
	void OnTriggerEnter(Collider other) {
		//Do no collide with the Boundary object
		if (other.tag == "Boundary") {
			return;
		}

		//Create an explosion
		Instantiate (explosion, transform.position, transform.rotation);

		//Was it the Player that collided with this object?
		if (other.tag == "Player") {
			//Make the player explode too!
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);

			//Call the GameOver method in GameController
			gameController.GameOver();
		}

		//Destroy the object that collided with this object
		Destroy (other.gameObject);

		//Destroy this object
		Destroy (gameObject);

		//Add to the player's score
		gameController.AddScore (scoreValue);
	}//end of OnTriggerEnter method
}
