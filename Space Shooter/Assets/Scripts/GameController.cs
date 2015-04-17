using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValue;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	private int score;

	//Instantiate hazards for the player
	IEnumerator SpawnWaves() {
		//Wait
		yield return new WaitForSeconds(startWait);

		while(true) {
			for(int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (hazard, spawnPosition, spawnRotation);

				//Wait
				yield return new WaitForSeconds(spawnWait);
			}//end of for loop

			yield return new WaitForSeconds(waveWait);
		}//end of while loop

	}//end of SpawnWaves method

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves());
	}
}