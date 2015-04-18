using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MoveTouchPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {
    //Set variables
    public float smoothing;

    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;
    private bool touched;
    private int pointerID;
    //As soon as this script runs, set these variables to their defaults
    void Awake()
    {
        direction = Vector2.zero;
        touched = false;
    }
    //When a finger is down, set touched to true, store the fingers ID, and it's original position
    public void OnPointerDown( PointerEventData data)
    {
        //Set out start point
        if (!touched)
        {
            touched = true;
            pointerID = data.pointerId;
            origin = data.position;
        }
        
    }
    //When the player drags their finger, find out the direction they're going by comparing the current location to origin
    public void OnDrag(PointerEventData data)
    {
        //Compare the difference, but only if it's the same finger
        if (data.pointerId == pointerID) { 
            Vector2 currentPosition = data.position;
            Vector2 directionRaw = currentPosition - origin;
            direction = directionRaw.normalized;
        }
    }
    //When the finger is lifted, reset the direction and if the screen is touched
    public void OnPointerUp(PointerEventData data)
    {        
        //Reset Everything
        if (data.pointerId == pointerID)
        {
            direction = Vector2.zero;
            touched = false;
        }
    }
    //A public getter to get the direction, after it has been smoothed.
    public Vector2 GetDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        return smoothDirection;
    }
}
