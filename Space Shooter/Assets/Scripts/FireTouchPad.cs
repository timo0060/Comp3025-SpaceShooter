using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class FireTouchPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
    //Declare Variables
    private bool touched;
    private int pointerID;
    private bool canFire;
    //When the script first runs, set touched to false
    void Awake()
    {
        touched = false;
    }
    //When a finger is placed down, set touched to true, get the pointer ID, and make can fire true
    public void OnPointerDown(PointerEventData data)
    {
        //Set out start point
        if (!touched)
        {
            touched = true;
            pointerID = data.pointerId;
            canFire = true;
        }

    }
    //When the finger is lifted, if it's the orginal finger, set everything back to false
    public void OnPointerUp(PointerEventData data)
    {
        //Reset Everything
        if (data.pointerId == pointerID)
        {
            canFire = false;
            touched = false;
        }
    }
    //Public getter to see if the player can fire.
    public bool GetCanFire()
    {
        return canFire;
    }
}
