using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
	public Knight knight;
	public Transform pellets;
	
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
		for(int i = 0; i < this.ghosts.Length; i++)
		{
			this.ghosts[i].gameObject.SetActive(true);
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
	}
	
	private void SetScore(int score)
	{
		this.score = score;
	}
	
	private void SetLives(int lives)
	{
		this.lives = lives;
	}
	
	public void GhostKilled(Ghost ghost)
	{
		SetScore(this.score + ghost.points);
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
}
