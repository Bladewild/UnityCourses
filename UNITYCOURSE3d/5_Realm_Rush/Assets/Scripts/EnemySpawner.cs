using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Text spawnedEmenies;
    [SerializeField] AudioClip spawnedEnemySFX;

    int score;

    [SerializeField] Transform enemyParentTransform;
    void Start()
    {
        
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEmenies.text = score.ToString();

    }

    IEnumerator RepeatedlySpawnEnemies()
    {

        while (true)
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var enemeySpawned = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemeySpawned.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        print("Ending Patrol");
    }

    private void AddScore()
    {
        score++;
        spawnedEmenies.text = score.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
