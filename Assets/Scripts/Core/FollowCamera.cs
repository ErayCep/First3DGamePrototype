using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGProject.Core
{
        public class FollowCamera : MonoBehaviour
    {
        public Transform target;
        Vector3 targetPosition;

        void Update()
        {
            transform.position = target.position;
        }
    }
}


