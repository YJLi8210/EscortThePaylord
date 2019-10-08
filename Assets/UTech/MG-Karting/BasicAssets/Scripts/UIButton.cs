using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using KartGame.KartSystems;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool buttonPressed;
    public KeyboardInput keyboard;
    public bool buttonDown;
    public bool buttonUp;
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
        if(buttonUp)
        {
            buttonDown = true;
            buttonUp = false;
        } else
        {
            buttonDown = false;
            buttonUp = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        buttonDown = false;
        buttonUp = true;
    }

    void Start()
    {
        buttonDown = false;
        buttonUp = true;
        keyboard = GameObject.Find("Kart").GetComponent<KeyboardInput>();
    }

    void Update()
    {

        keyboard.isShiftButtonPressed = buttonPressed;
        keyboard.isShiftButtonDown = buttonDown;
        buttonDown = false;
    }
}