using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace WorldTime
{ 
    public class WorldTime : MonoBehaviour
    {
        [SerializeField] private float _dayLength;

        private TimeSpan _currentTime;
    }

}
