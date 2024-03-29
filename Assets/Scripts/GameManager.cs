using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
	public Knight knight;
	public Transform pellets;
	
	public TMP_Text scoreText;
	public TMP_Text livesText;
	public TMP_Text poweredUpText;
	
	public int ghostMultiplier;
	public int score;
	public int lives;
	private bool inLevel1;
	private int level = 1;
	public bool poweredUp = false;
	
	private void Start()
	{
		Debug.Log("in start");
		NewGame();
	}
	
	private void Update()
	{
		
	}
	private void NewGame()
	{
		Debug.Log("in new game");
		inLevel1 = GameObject.Find("level1") != null;
		SetScore(0);
		SetLives(3);
		NewRound();
	}
	
	private void NewRound()
	{
		//Debug.Log("current round: " + level);
		if(level == 2)
		{
			SceneManager.LoadScene("Level2");
		}
		foreach(Transform pellet in this.pellets)
		{
			pellet.gameObject.SetActive(true);
		}
		
		Reset();
	}
	
	private void Reset()
	{
		ResetMultiplier();
		
		for(int i = 0; i < this.ghosts.Length; i++)
		{
			this.ghosts[i].gameObject.SetActive(true);
		}
		if(inLevel1)
		{
			this.knight.transform.position = new Vector3(0f, -4.5f, 0f);
			Debug.Log("current round setup: " + level);
		}
		else if(!inLevel1)
		{
			this.knight.transform.position = new Vector3(-1f, -5.5f, 0f);
			//Debug.Log("current round setup: " + level);
		}
		this.knight.gameObject.SetActive(true);
	}
	
	private void GameOver()
	{
		for(int i = 0; i < this.ghosts.Length; i++)
		{
			this.ghosts[i].gameObject.SetActive(false);
		}
		this.knight.gameObject.SetActive(false);
		SceneManager.LoadScene("Lose");
    }
	
	private void SetScore(int score)
	{
		this.score = score;
		scoreText.text = "Score: " + score.ToString("D4");
	}
	
	private void SetLives(int lives)
	{
		this.lives = lives;
		livesText.text = "Lives: " + lives.ToString();
	}
	
	public void GhostKilled(Ghost ghost)
	{
		ghost.gameObject.SetActive(false);
		SetScore(this.score + (ghost.points * ghostMultiplier));
		this.ghostMultiplier++;
	}
	
	public void KnightKilled()
	{
		this.knight.gameObject.SetActive(false);
		
		SetLives(this.lives - 1);
		
		if(this.lives > 0)
			Invoke(nameof(Reset), 3f);
		else
			GameOver();
	}
	
	public void PelletEaten(Pellet pellet)
	{
		pellet.gameObject.SetActive(false);
		SetScore(this.score + pellet.points);
		if(!EatenAllPellets() && (GameObject.Find("level1") == null))
		{
			SceneManager.LoadScene("Win");
		}
		if(!EatenAllPellets())
		{
			this.knight.gameObject.SetActive(false);
			level++;
			Invoke(nameof(NewRound), 3f);
		}
	}
	
	public void PowerPelletEaten(PowerPellet pellet)
	{
		poweredUp = true;
		poweredUpText.enabled = true;
		PelletEaten(pellet);
		CancelInvoke();
		Invoke(nameof(ResetMultiplier), pellet.duration);
	}
	
	private bool EatenAllPellets()
	{
		foreach(Transform pellet in this.pellets)
		{
			if(pellet.gameObject.activeSelf)
			{
				return true;
			}
		}
		return false;
	}
	
	private void ResetMultiplier()
	{
		Debug.Log("in reset mult");
		this.ghostMultiplier = 1;
		poweredUp = false;
		poweredUpText.enabled = false;
	}
}
