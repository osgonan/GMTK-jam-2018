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
    public int MaxEnemieCapacity;
    int EnemyCatched=0;
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

    /*public void clearEnemies() {
        EnemyCatched.Clear();
    }
    */


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hole") {
            Destroy(other.gameObject);
        }
        if (other.tag == "Enemy") {
            Debug.Log("Catched");

            EnemyCatched++;
            Destroy(other.gameObject);
            if (EnemyCatched >= MaxEnemieCapacity) {
                Destroy(this.gameObject);
            }
            
            
        }
    }
}
