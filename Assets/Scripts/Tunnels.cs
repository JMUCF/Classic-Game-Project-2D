using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnels : MonoBehaviour
{
	public Transform output;
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Vector3 position = collision.transform.position;
		position.x = this.output.position.x;
		position.y = this.output.position.y;
		
		collision.transform.position = position;
	}
}
