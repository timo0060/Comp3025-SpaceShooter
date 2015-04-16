using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) {
		//Do no collide with the Boundary object
		if (other.tag == "Boundary") {
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}

		Destroy (other.gameObject);
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
