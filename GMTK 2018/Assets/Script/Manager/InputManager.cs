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

        bool diggin = false;
        public float timeButtonPressed=0;

        public float timeToCreateHole;

        public GameObject DigginPosition;


        private void FixedUpdate()
        {
            moving = false;
            Vector3 direccion = new Vector3();

            if (Input.GetKey(KeyCode.Space))
            {
                
                timeButtonPressed += Time.time;
                diggin = true;
            }
            else {
                timeButtonPressed = 0;
                diggin = false;
            }
            if (!diggin)
            {
                if (Math.Abs(Input.GetAxis("Horizontal")) > 0.5)
                {
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        this.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    else
                    {
                        this.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    direccion.x = Input.GetAxis("Horizontal") * status.speedx * Time.deltaTime;
                    moving = true;
                }

                if (Math.Abs(Input.GetAxis("Vertical")) > 0.5)
                {
                    direccion.z = Input.GetAxis("Vertical") * status.speedy * Time.deltaTime;
                    moving = true;
                }
                if (moving)
                {
                    Transform objeto = this.GetComponentInChildren<Transform>();
                    mover(GetComponent<Transform>(), objeto, direccion.x, direccion.z, true);
                }
            }
            else {
                if (timeToCreateHole < timeButtonPressed) {
                    this.GetComponent<PlayerActions>().CreateHole(DigginPosition.transform);
                }
            }
                
        }
    }
}