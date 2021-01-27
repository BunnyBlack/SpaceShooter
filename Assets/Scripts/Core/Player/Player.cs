using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Player
{
    public class Player : MonoBehaviour
    {
        private void Start()
        {
            InitPosition();
        }

        private void InitPosition()
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }

}
