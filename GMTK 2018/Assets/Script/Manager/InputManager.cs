using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2018
{
    public class InputManager : Physics2D
    {

        public  PlayerStats status;

        private void FixedUpdate()
        {
            Vector3 direccion = new Vector3();
            if (Math.Abs(Input.GetAxis("Horizontal")) > 0.5)
            {
                direccion.x = Input.GetAxis("Horizontal") * status.speedx * Time.deltaTime;
            }

            if (Math.Abs(Input.GetAxis("Vertical")) > 0.5)
            {
                direccion.z = Input.GetAxis("Vertical") * status.speedy * Time.deltaTime;

            }


            /*if (Input.GetButton("Fire")) {
            }
            if (Input.GetButton("Jump"))
            {
            }*/

            mover(GetComponent<Transform>(), direccion.x, direccion.z,true);
        }
    }
}