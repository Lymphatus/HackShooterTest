using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab.gameObject);
        enemy.transform.position = transform.position;
        //Rotate to the player
    }
}
