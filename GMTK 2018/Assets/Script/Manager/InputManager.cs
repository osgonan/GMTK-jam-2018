using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2018
{
    public class InputManager : Physics2D
    {
        public Animator animator;

        public  PlayerStats status;
        bool moving = false;

        bool diggin = false;
        bool digged = false;
        public float timeButtonPressed=0;

        public float timeToCreateHole;

        public GameObject digginPosition;


        private void FixedUpdate()
        {
            moving = false;
            Vector3 direccion = new Vector3();
            if (Input.GetKey("escape"))
                Application.Quit();
            if (Input.GetKey(KeyCode.Space))
            {
                
                timeButtonPressed += Time.time;
                diggin = true;
                GetComponent<PlayerSound>().playAttackSound();
            }
            else {
                timeToCreateHole += timeButtonPressed;
                timeButtonPressed = 0;
                diggin = false;
                digged = false;
            }
            if (!diggin)
            {
                if (Math.Abs(Input.GetAxis("Horizontal")) > 0.5)
                {
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        this.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else
                    {
                        this.GetComponent<SpriteRenderer>().flipX = true;
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
                        GetComponent<PlayerSound>().playWalkSound();

                    
                }
            }
            else {
                if (timeToCreateHole < timeButtonPressed && !digged) {
                    this.GetComponent<PlayerActions>().CreateHole(digginPosition.transform);
                    digged = true;

                }
            }
            animator.SetBool("walking", moving);
            animator.SetBool("diggin", diggin);
        }
    }
}