using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public List<Transform> spawners;
    public List<GameObject> enemies;
    public List<float> spawnEnemyRandom;

    public List<GameObject> spawnedEnemy;

    public int maxEnemies;

    public float timeForGenerationOfEnemies;
    public float timeForNewHorde;


    public void  addSpawner(Transform spawnPosition) {
        spawners.Add(spawnPosition);

    }

    public void IncreaseMaxEnemies(int increase) {
        maxEnemies += increase;
    }

    public void spawnEnemy() {
        float spawnerRandom = Random.Range(0, 100);
        for (int i = 0; i < enemies.Count; i++) {

            if (spawnerRandom <= spawnEnemyRandom[i] && spawnedEnemy.Count<= maxEnemies)
            {
                int position = Random.Range(0, spawners.Count - 1);
                spawnedEnemy.Add(Instantiate(enemies[i],spawners[position]));
                break;
            }
        }

    }

    public void StartHorde() {
        InvokeRepeating("spawnEnemy", timeForNewHorde, timeForGenerationOfEnemies);
    }

    public void FixedUpdate()
    {

        StartHorde();

    }
}
