﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SpookSuite.Components
{
    internal class KBInput : MonoBehaviour
    {
        private float sprintMultiplier = 1f;
        private float movementSpeed = 10f;

        public Vector3 movement;

        private void Update()
        {
            if (Cursor.visible) return;

            Debug.Log("KBInput Update");

            Vector3 input = new Vector3();

            if(Input.GetKey(KeyCode.W)) input += transform.forward;
            if(Input.GetKey(KeyCode.S)) input -= transform.forward;
            if(Input.GetKey(KeyCode.A)) input -= transform.right;
            if(Input.GetKey(KeyCode.D)) input += transform.right;
            if(Input.GetKey(KeyCode.Space)) input += transform.up;
            if(Input.GetKey(KeyCode.LeftControl)) input -= transform.up;

            if(input.Equals(Vector3.zero)) return;

            sprintMultiplier = Input.GetKey(KeyCode.LeftShift) ? Mathf.Min(sprintMultiplier + (5f * Time.deltaTime), 5f) : 1f;
            movement = input * Time.deltaTime * movementSpeed * sprintMultiplier;
            transform.position += movement;
        }

    }
}
