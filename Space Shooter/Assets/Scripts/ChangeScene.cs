using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    //Recieves the name of the next scene that will be loaded
    public void ChangeToScene(string sceneToChange)
    {
        //Load that scene
        Application.LoadLevel(sceneToChange);
    }
    //Exits the application
    public void ExitGame()
    {
        Application.Quit();
    }
}
