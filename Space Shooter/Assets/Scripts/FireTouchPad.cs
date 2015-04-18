using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class FireTouchPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    private bool touched;
    private int pointerID;
    private bool canFire;

    void Awake()
    {
        touched = false;
    }

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

    public void OnPointerUp(PointerEventData data)
    {
        //Reset Everything
        if (data.pointerId == pointerID)
        {
            canFire = false;
            touched = false;
        }
    }

    public bool GetCanFire()
    {
        return canFire;
    }
}
