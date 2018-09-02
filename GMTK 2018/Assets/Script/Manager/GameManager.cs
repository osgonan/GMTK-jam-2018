using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int food;
    public int woods;
    public int garbage;
    public int actualDays;
    public float timeBetweenDays;
    public int maxDaysToSurvive;
    public int Score;

    public bool gamePaused;
    public bool gameOver;

    public int VillagerAlive;
    public int villagerDeath;

    public void foodAsBait(int quantity) {
        food -= quantity;
    }
    public void woodAsNet() {
        woods -= 10;
    }

    public void woodToHideHole() {
        woods -= 10;
    }

    public void garbageToStinkyBomb() {
        garbage -= 15;
    }

    public void ProcessEnemiesInHole(List<GameObject> enemies) {
        foreach (GameObject enemy in enemies) {
            switch (enemy.tag) {
                case "Bat":
                    food += 5;
                    break;
                case "Giant":
                    food += 20;
                    woods += 15;
                    garbage += 10;
                    break;
                case "Troll":
                    woods += 30;
                    garbage += 5;
                    break;
                case "Wolf":
                    food += 30;
                    break;

            } 

        }
    }
}
