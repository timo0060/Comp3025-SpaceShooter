using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	private int score;
	private bool restart;
	private bool gameOver;

	public GameObject hazard;
	public Vector3 spawnValue;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	public Text gameoverText;

	/*
	 * Start is like the constructor for Unity GameObjects.
	 * This is where properties should be initialized.
	 */
	void Start () {
		gameOver = false;
		restart = false;
		gameoverText.text = "";
		score = 0;
		UpdateScore ();

		//In order to use the WaitForSeconds method, SpawnWaves changed to a Coroutine
		StartCoroutine(SpawnWaves());
	}//end of Start method

	/*
	 * The Update method in Unity is like Unreal Engine's Tick() method
	 * It gets called each time the frame is redrawn/updated.
	 */
	void Update() {

		//If the restart flag is set check for the R key
		if (restart) {
			if( Input.GetKeyDown(KeyCode.R)) {
				//Reload the currently loaded level
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}//end of Update method

	/*
	 * Update the game score text displayed
	 * in the game
	 */
	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}//end of UpdateScore method

	/*
	 * SpawnWaves is essentially the infinate game loop, since the game
	 * ultimately is a never ending wave of Asteroids and Enemies.
	 * 
	 * The SpawnWaves method is declared as a Coroutine. It sort of acts like a callback
	 * by using yield return to temporarily exit out of the method for a period of time
	 * determined by the return IEnumerator and then execution resumes from that return
	 * point.
	 */
	IEnumerator SpawnWaves() {
		//Wait before spawning the initial round of Asteroids
		yield return new WaitForSeconds(startWait);

		while(true) {
			for(int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (hazard, spawnPosition, spawnRotation);

				//Wait between each Asteroid spawn to avoid collissions with other Asteroids
				yield return new WaitForSeconds(spawnWait);
			}//end of for loop

			//Wait before spawning another round of Asteroids
			yield return new WaitForSeconds(waveWait);

			if(gameOver){

				//break out of the while loop
				break;
			}
		}//end of while loop

	}//end of SpawnWaves coroutine

	/*
	 * AddScore method adds a value to the score
	 * accumulator and calls the UpdateScore method
	 * to redraw the score text displayed in game
	 */
	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}//end of AddScore method

	/*
	 * Handle the end of games
	 */
	public void GameOver() {
        //Wait 2 seconds, then call the function "GameOverScreen" when the player dies
        Invoke("GameOverScreen", 2.0f);
	}//end of GameOver method

    public void GameOverScreen()
    {
        //Load the GameOver scene
        Application.LoadLevel("GameOver");
    }
}