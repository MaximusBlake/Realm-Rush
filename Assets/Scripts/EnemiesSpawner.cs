using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesSpawner : MonoBehaviour {
    [Range(0.1f,60f)] [SerializeField] float secondsBetweenSpawns= .5f;
    [SerializeField] EnemyCollision enemyPrefab;
    [SerializeField] Transform parent;
    [SerializeField] int enemiesSpawned=0;
    [SerializeField] Text enemiesText;

    void Start () {
        StartCoroutine(RepeatedSpawnEnemies());
        enemiesText.text = enemiesSpawned.ToString();
	}
    IEnumerator RepeatedSpawnEnemies()
    {
        while (true)//forever
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = parent;
            EnemySpawned();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void EnemySpawned()
    {
        enemiesSpawned++;
        enemiesText.text = enemiesSpawned.ToString();
    }
}
