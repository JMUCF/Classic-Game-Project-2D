using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed = 5f;
	public float speedMult = 1f;
	public Vector2 initialDirection;
	public LayerMask wallLayer;
	
    public new Rigidbody2D rigidbody;
	public Vector2 direction;
	public Vector2 nextDirection;
	public Vector3 startingPosition;
	
	private void Awake()
	{
		this.rigidbody = GetComponent<Rigidbody2D>();
		this.startingPosition = this.transform.position;
	}
	
	private void Start()
	{
		Reset();
	}
	
	public void Reset()
	{
		this.speedMult = 1f;
		this.direction = this.initialDirection;
		this.nextDirection = Vector2.zero;
		this.transform.position = this.startingPosition;
		this.rigidbody.isKinematic = false;
		this.enabled = true;
	}
	
	private void Update()
	{
		if(this.nextDirection != Vector2.zero)
		{
			SetDirection(this.nextDirection);
		}
	}
	
	private void FixedUpdate()
	{
		Vector2 position = this.rigidbody.position;
		Vector2 translation = this.direction * this.speed * this.speedMult * Time.fixedDeltaTime;
		this.rigidbody.MovePosition(position + translation);
	}
	
	public void SetDirection(Vector2 direction, bool forced = false)
	{
		if(!Blocked(direction) || forced)
		{
			this.direction = direction;
			this.nextDirection = Vector2.zero;
		}
		else
		{
			this.nextDirection = direction;
		}
	}
	
	public bool Blocked(Vector2 direction)
	{
		RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * .75f, 0f, direction, 1.5f, this.wallLayer);
		return hit.collider != null;
	}
	
}
