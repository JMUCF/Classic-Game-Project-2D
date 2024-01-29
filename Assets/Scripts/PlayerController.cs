using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
	private bool playerInput = true;
	
    void Start()
    {
        transform.Translate(new Vector2(0, moveSpeed) * Time.deltaTime); //move the character up
    }

    void Update()
    {
        Movement();
    }
	
	IEnumerator WaitToTurn()
	{
		//Debug.Log("Entered the wait coroutine");
		playerInput = false;
		yield return new WaitForSeconds(.5f);
		//Debug.Log("Leaving the wait coroutine");
		playerInput = true;
	}
	
	void Movement() //		#####	fix bug where player turns after letting go of key	#####
	{				//		##### 	change movement logic to use WASD					#####
		if(Input.GetAxis("Horizontal") > 0 && playerInput == true)
		{
			transform.Translate(new Vector2(moveSpeed, 0) * Time.deltaTime); //right
		}
		else if(Input.GetAxis("Horizontal") < 0 && playerInput == true)
		{
			//Debug.Log("Right");
			transform.Translate(new Vector2(-moveSpeed, 0) * Time.deltaTime);
		}
		else if(Input.GetAxis("Vertical") > 0 && playerInput == true)
		{
			//Debug.Log("Right");
			transform.Translate(new Vector2(0, moveSpeed) * Time.deltaTime);
		}
		else if(Input.GetAxis("Vertical") < 0 && playerInput == true)
		{
			//Debug.Log("Right");
			transform.Translate(new Vector2(0, -moveSpeed) * Time.deltaTime);
		}
	}
}
