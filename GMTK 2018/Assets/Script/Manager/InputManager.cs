using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2018
{
    public class InputManager : Physics2D
    {

        PlayerStats status;

        private void FixedUpdate()
        {
            if (Math.Abs(Input.GetAxis("Horizontal")) > 0.5)
            {
            }

            if (Math.Abs(Input.GetAxis("Vertical")) > 0.5)
            {
            }

            if (Input.GetButton("Fire")) {
            }
            if (Input.GetButton("Jump"))
            {
            }
        }
    }
}