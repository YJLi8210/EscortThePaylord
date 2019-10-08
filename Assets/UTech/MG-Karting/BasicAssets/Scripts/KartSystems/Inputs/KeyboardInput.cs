using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KartGame.KartSystems
{
    /// <summary>
    /// A basic keyboard implementation of the IInput interface for all the input information a kart needs.
    /// </summary>
    public class KeyboardInput : MonoBehaviour, IInput
    {
        UIButton shiftButton;
        Joystick virtualJoystick;
        public bool isShiftButtonPressed = false;
        public bool isShiftButtonDown = false;
        public float Acceleration
        {
            get { return m_Acceleration; }
        }
        public float Steering
        {
            get { return m_Steering; }
        }
        public bool BoostPressed
        {
            get { return m_BoostPressed; }
        }
        public bool FirePressed
        {
            get { return m_FirePressed; }
        }
        public bool HopPressed
        {
            get { return m_HopPressed; }
        }
        public bool HopHeld
        {
            get { return m_HopHeld; }
        }

        float m_Acceleration;
        float m_Steering;
        bool m_HopPressed;
        bool m_HopHeld;
        bool m_BoostPressed;
        bool m_FirePressed;

        bool m_FixedUpdateHappened;

        void Update ()
        {
            shiftButton = FindObjectOfType<UIButton>();
            virtualJoystick = FindObjectOfType<Joystick>();
            //Debug.Log("hori: " + virtualJoystick.Horizontal);
            //Debug.Log("vertical: " + virtualJoystick.Vertical);

            //if (shiftButton != null)
            //{
                //Debug.Log("Found button");
            //}
            if (Input.GetKey (KeyCode.UpArrow) || virtualJoystick.Vertical > 0.0f)
                m_Acceleration = 1f;
            else if (Input.GetKey (KeyCode.DownArrow) || virtualJoystick.Vertical < 0.0f)
                m_Acceleration = -1f;
            else
                m_Acceleration = 0f;

            if ((Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) 
                    || virtualJoystick.Horizontal < 0.0f)
                m_Steering = -1f;
            else if ((!Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.RightArrow))
                       || virtualJoystick.Horizontal > 0.0f)
                m_Steering = 1f;
            else
                m_Steering = 0f;

            m_HopHeld = (Input.GetKey (KeyCode.Space) || isShiftButtonPressed);

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;

                m_HopPressed = false;
                m_BoostPressed = false;
                m_FirePressed = false;
            }

            m_HopPressed |= ((Input.GetKeyDown (KeyCode.Space) || isShiftButtonDown));
            m_BoostPressed |= Input.GetKeyDown (KeyCode.RightShift);
            m_FirePressed |= Input.GetKeyDown (KeyCode.RightControl);

        }

        public void UIShiftButtonPressed()
        {
        }

        void FixedUpdate ()
        {
            m_FixedUpdateHappened = true;
        }
    }
}