﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShootingGame
{
    [CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
    public class Gun : ScriptableObject
    {
        public string name;
        public float fireRate;
        public float aimSpeed;
        public GameObject prefab;
    }

}
