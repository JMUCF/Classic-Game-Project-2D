using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int points = 10;
	
	public AudioClip collisionSound; 
    private AudioSource audioSource;
	
	private void start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = collisionSound;
	}
	
	protected virtual void Eat()
	{
		FindObjectOfType<GameManager>().PelletEaten(this);
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.layer == LayerMask.NameToLayer("Knight"))
		{
			Eat();
		}
	}
	
	private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Knight"))
        {
            audioSource.Play();
        }
    }
}
