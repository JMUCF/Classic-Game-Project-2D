using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;
	private int score = 0;
	private int lives = 3;
    //private int zoom = 5; //for camera to show full map
    //private float followSpeed = 2f;
    //private float yOffset = 1f;
    //public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = ("Lives: " + lives);
        //Camera.main.orthographicSize = zoom;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 newPos = new Vector3(player.position.x, player.position.y + yOffset, -10f);
        //transform.position = Vector3.Slerp(transform.position, newPos, followSpeed*Time.deltaTime);
    }

    public void IncreaseScore() //increases the score when collecting dots
    {
        score += 25;
        scoreText.text = ("Score: " + score.ToString("0000"));
    }
}
