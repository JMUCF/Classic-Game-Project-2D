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
	
	public int ghostMultiplier;
	public int score;
	public int lives;
	
	private void Start()
	{
		NewGame();
	}
	
	private void Update()
	{
		if(Input.anyKeyDown && this.lives <= 0)
		{
			NewGame();
		}
	}
	private void NewGame()
	{
		SetScore(0);
		SetLives(3);
		NewRound();
	}
	
	private void NewRound()
	{
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
		this.knight.transform.position = new Vector3(-1f, -5.5f, 0f);
		this.knight.gameObject.SetActive(true);
	}
	
	private void GameOver()
	{
		for(int i = 0; i < this.ghosts.Length; i++)
		{
			this.ghosts[i].gameObject.SetActive(false);
		}
		this.knight.gameObject.SetActive(false);
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
		
		if(!EatenAllPellets())
		{
			this.knight.gameObject.SetActive(false);
			Invoke(nameof(NewRound), 3f);
		}
	}
	
	public void PowerPelletEaten(PowerPellet pellet)
	{
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
		this.ghostMultiplier = 1;
	}
}
