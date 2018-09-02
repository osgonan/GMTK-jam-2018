using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GMTK2018
{
    public class Physics2D : MonoBehaviour
    {
        public Camera camara;
        public Vector3 forward, right;
        public void Start()
        {
            forward = camara.transform.forward;
            forward.y = 0;
            forward = Vector3.Normalize(forward);
            right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;


        }
        protected void mover(Transform transform,Transform esquipo, float dx,float dy,bool activo) {
            if (activo) {
                Vector3 rightMovement = right * dx;
                Vector3 upMovement = forward * dy;

                Debug.Log(rightMovement + " " + upMovement);
                Vector3 headling = Vector3.Normalize(upMovement + rightMovement);
                esquipo.forward = headling;
                transform.position += rightMovement;
                transform.position += upMovement;

            }
        }
    }
}