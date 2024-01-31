using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
	public Movement movement;
	
	private void Awake()
	{
		this.movement = GetComponent<Movement>();
	}
	
    private void Update()
	{
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			this.movement.SetDirection(Vector2.up);
		else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			this.movement.SetDirection(Vector2.left);
		else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			this.movement.SetDirection(Vector2.down);
		else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			this.movement.SetDirection(Vector2.right);
	}
}
