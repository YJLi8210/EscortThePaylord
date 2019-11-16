using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public enum InputType { Keyboard, Mobile }

[RequireComponent(typeof(CarController))]
public class CarUserControl : MonoBehaviour
{
    [SerializeField]
    InputType inputType;

    CarController controller;

    void Awake()
    {
        controller = GetComponent<CarController>();
    }

    void FixedUpdate()
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // }

        float h = 0f;
        float v = 0f;
        float handbrake = 0f;

        switch (inputType)
        {
            case InputType.Keyboard:

                h = Input.GetAxis("Horizontal");
                v = Input.GetAxis("Vertical");
                //handbrake = Input.GetAxis("Jump");

                break;

            case InputType.Mobile:

                h = CrossPlatformInputManager.GetAxis("Horizontal");
                v = CrossPlatformInputManager.GetAxis("Vertical");
                //handbrake = CrossPlatformInputManager.GetAxis("Jump");

                break;
        }

        controller.Move(h, v, v, handbrake);
    }
}
