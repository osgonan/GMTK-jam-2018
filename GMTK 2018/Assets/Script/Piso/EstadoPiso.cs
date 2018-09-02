using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPiso : MonoBehaviour {

    public GameManager manager;

    bool holeCreated; //check if a hole is created
    bool holeHidden; // hide the floor for get more chances of the enemy to fall down or get caught in the net
    bool hasBait; // if floor has bait (you can only put bait if you had de resource and the floor is hidden)
    bool netCreated;  //if enemy fly they get trap by the net (work as a hole but for flying enemies)
    int quantityBait; //more bait more easy is the enemy to get caught
    int MaxEnemieCapacity;
    List<GameObject> EnemyCatched;
    float chancestoGetCaught; //the chances to get caught by the floor


    public void CretateHole() {
        if (!netCreated && !holeCreated) {
            holeCreated = true;
        }
    }

    public void CreateNet() {
        if (!netCreated && !holeCreated)
        {
            netCreated = true;
        }
    }

    public void putBait(int quantity) {
        quantityBait += quantity;
        GetComponent<SphereCollider>().radius = 4* quantityBait;
    }

    public void clearEnemies() {
        EnemyCatched.Clear();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
