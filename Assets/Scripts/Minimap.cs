using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShootingGame
{
    public class Minimap : MonoBehaviour
    {
        public Transform player;

        void LateUpdate()
        {
            //minimap follow where player go as 2D
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;

            //minimap follo player direction as 3D
            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }
    }


}

