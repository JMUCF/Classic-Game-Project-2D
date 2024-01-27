using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
	private int score = 0;
	private int lives = 3;
    private int zoom = 10; //for camera to show full map

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = zoom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore() //increases the score when collecting dots
    {
        score += 25;
        scoreText.text = ("Score: " + score.ToString("0000"));
    }
}
