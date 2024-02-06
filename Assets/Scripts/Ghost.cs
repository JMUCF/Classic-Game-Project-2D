using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int points = 100;
	public Ghost ghost;
	public Movement movement;
	
	private void Awake()
	{
		this.movement = GetComponent<Movement>();
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("enemy"), LayerMask.NameToLayer("enemy"));
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Node node = collision.GetComponent<Node>();
		
		if(node != null)
		{
			int index = Random.Range(0, node.availableDirections.Count);
			
			if(node.availableDirections[index] == -this.ghost.movement.direction && node.availableDirections.Count > 1)
			{
				index++;
				
				if(index >= node.availableDirections.Count)
				{
					index = 0;
				}
			}
			
			this.ghost.movement.SetDirection(node.availableDirections[index]);
		}
	}
}
