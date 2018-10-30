using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int hits =10;

    ScoreBoard scoreBoard;
    int timesHit = 0;

    // Use this for initialization
    void Start () {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void AddNonTriggerBoxCollider()
    {
        gameObject.AddComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnParticleCollision(GameObject other)
    {
        hits--;
       scoreBoard.ScoreHit();
       if (hits <= 0)
         KillEnemy();
      
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(DeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
