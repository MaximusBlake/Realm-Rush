using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour {
    [Range(0.1f,60f)] [SerializeField] float secondsBetweenSpawns= .5f;
    [SerializeField] EnemyCollision enemyPrefab;
    [SerializeField] Transform parent;
	
	void Start () {
        StartCoroutine(RepeatedSpawnEnemies());
	}
    IEnumerator RepeatedSpawnEnemies()
    {
        while (true)//forever
        {
            var newEnemy= Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = parent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
