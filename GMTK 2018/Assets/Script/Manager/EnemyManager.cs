using GMTK2018;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public List<Transform> spawners;
    public List<GameObject> enemies;


    [System.Serializable]
    public class ListContainer
    {
        public List<GameObject> ListRouts = new List<GameObject>();
    }

    [SerializeField] private List<ListContainer> routsX;


    public List<float> spawnEnemyRandom;

    public List<GameObject> spawnedEnemy;

    public int maxEnemies;

    public float timeForGenerationOfEnemies;
    public float timeForNewHorde;

    public PlayerStats playerStats;


    public void  addSpawner(Transform spawnPosition) {
        spawners.Add(spawnPosition);

    }

    public void IncreaseMaxEnemies(int increase) {
        maxEnemies += increase;
    }

    public void spawnEnemy() {
        float spawnerRandom = Random.Range(0, 100);
        for (int i = 0; i < enemies.Count; i++) {
            if (spawnerRandom >= spawnEnemyRandom[i] && spawnerRandom < spawnEnemyRandom[i + 1] && spawnedEnemy.Count<= maxEnemies)
            {
                int index = Random.Range(0, routsX.Count);
                enemies[i].GetComponent<MoveBetweenTwoPoints>().pointX = routsX[index].ListRouts; enemies[i].GetComponent<MoveBetweenTwoPoints>();
                enemies[i].GetComponent<MoveBetweenTwoPoints>().playerStats = playerStats;
                int position = Random.Range(0, spawners.Count - 1);
                spawnedEnemy.Add(Instantiate(enemies[i],spawners[position].position,spawners[position].rotation));
            }
        }

    }

    public void StartHorde() {
        InvokeRepeating("spawnEnemy", timeForNewHorde, timeForGenerationOfEnemies);
    }

    void Start()
    {

        StartHorde();

    }
}
