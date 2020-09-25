using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShootingGame
{
    public class Look : MonoBehaviour
    {
        #region Variables

        
        public static bool cursorLocked = true;

        public Transform player;
        public Transform cams;
        public Transform Weapon; 

        public float xSensitivity;
        public float ySensitivity;
        public float maxAngle;
        
        private Quaternion camCenter;
        #endregion

        #region Monobehaviour Callbacks

        void Start()
        {
            camCenter = cams.localRotation; //set rotation origin for cameras to camCenter
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            SetY();
            SetX();
        }
        #endregion

        #region Private Methods
        void SetY()
        {
            float t_input = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
            Quaternion t_adj = Quaternion.AngleAxis(t_input, -Vector3.right);
            Quaternion t_delta = cams.localRotation * t_adj;

            if (Quaternion.Angle(camCenter, t_delta) < maxAngle)
            {
                cams.localRotation = t_delta;
            }

            Weapon.rotation = cams.rotation;
        }

        void SetX()
        {
            float t_input = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
            Quaternion t_adj = Quaternion.AngleAxis(t_input, Vector3.up);
            Quaternion t_delta = player.localRotation * t_adj;
            player.localRotation = t_delta;
        }
        #endregion

    }
}

