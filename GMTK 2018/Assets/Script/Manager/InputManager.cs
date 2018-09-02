using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2018
{
    public class InputManager : Physics2D
    {

        public  PlayerStats status;
        bool moving = false;
        private void FixedUpdate()
        {
            moving = false;
            Vector3 direccion = new Vector3();
            if (Math.Abs(Input.GetAxis("Horizontal")) > 0.5)
            {
                direccion.x = Input.GetAxis("Horizontal") * status.speedx * Time.deltaTime;
                moving = true;
            }

            if (Math.Abs(Input.GetAxis("Vertical")) > 0.5)
            {
                direccion.z = Input.GetAxis("Vertical") * status.speedy * Time.deltaTime;
                moving = true;
            }


            /*if (Input.GetButton("Fire")) {
            }
            if (Input.GetButton("Jump"))
            {
            }*/
            if (moving) {
                Transform objeto = this.GetComponentInChildren<Transform>();
                mover(GetComponent<Transform>(), objeto, direccion.x, direccion.z, true);
            }
                
        }
    }
}