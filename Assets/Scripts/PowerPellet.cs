using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Pellet
{
    public float duration = 10f;
	
	protected override void Eat()
	{
		FindObjectOfType<GameManager>().PowerPelletEaten(this);
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.layer == LayerMask.NameToLayer("Knight"))
		{
			Eat();
		}
	}
}
