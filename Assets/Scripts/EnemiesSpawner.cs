using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemiesSpawner : MonoBehaviour {
    [Range(0.1f,60f)] [SerializeField] float secondsBetweenSpawns= .5f;
    [SerializeField] EnemyCollision enemyPrefab;
    [SerializeField] Transform parent;
    [SerializeField] int enemiesSpawned=0;
    [SerializeField] Text enemiesSpawnedText;

    [SerializeField] AudioClip spawnSFX;
    
    void Start () {
        StartCoroutine(RepeatedSpawnEnemies());
        enemiesSpawnedText.text = enemiesSpawned.ToString();
	}
    IEnumerator RepeatedSpawnEnemies()
    {
        while (enemiesSpawned<=50)//forever
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = parent;
            EnemySpawned();
            GetComponent<AudioSource>().PlayOneShot(spawnSFX);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void EnemySpawned()
    {
        enemiesSpawned++;
        enemiesSpawnedText.text = enemiesSpawned.ToString();
    }
}
