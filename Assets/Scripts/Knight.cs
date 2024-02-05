using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
	public Movement movement;
	public float health;
	public float maxHealth = 3;

	
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

	void OnCollisionEnter2D(Collision2D col)
{
	if (col.gameObject.name == "Skeleton")
	{
		transform.position = new Vector3(-1.091f, -5.5f, 0f);

	}

}


}
