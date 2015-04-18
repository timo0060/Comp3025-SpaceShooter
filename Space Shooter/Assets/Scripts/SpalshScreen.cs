using UnityEngine;
using System.Collections;

public class SpalshScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Wait 3 seconds, then call the function, "EndSplashScreen"
        Invoke("EndSplashScreen", 3.0f);
	}
    //Load the main menu
    public void EndSplashScreen()
    {
        Application.LoadLevel("menu");
    }
}
