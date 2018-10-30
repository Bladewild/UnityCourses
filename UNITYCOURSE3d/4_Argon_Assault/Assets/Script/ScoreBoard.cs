using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    int score;
    Text scoreText;
    [SerializeField] int scorePerHit = 10;
    // Use this for initialization
    void Start() {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();

    }

    public void ScoreHit()
    {
        score+= scorePerHit;
        scoreText.text = score.ToString();
    }
    
}
