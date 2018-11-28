using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour {
    [Range(0.5f,60f)] [SerializeField] float secondsBetweenSpawns= 2f;
    [SerializeField] EnemyCollision enemyPrefab;
	
	void Start () {
        StartCoroutine(RepeatedSpawnEnemies());
	}
    IEnumerator RepeatedSpawnEnemies()
    {
        while (true)//forever
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
