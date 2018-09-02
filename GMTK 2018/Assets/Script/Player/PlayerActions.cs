using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {

   public GameObject hole;
   public GameObject Net;

    public GameObject holeHidden;
    public GameObject holeWithBait;

    public GameManager manager;

    public float timeToCreateHole;



  

    public void CreateHole(Transform transform) {
        Instantiate(hole, transform.position, transform.rotation);
    }
}
