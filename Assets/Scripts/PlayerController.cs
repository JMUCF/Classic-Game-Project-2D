using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
	private bool playerInput = true;
	
    void Start()
    {
        
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
		transform.Translate(new Vector3(0, 0, moveSpeed) * Time.deltaTime); //move the character forward
		if(Input.GetAxis("Horizontal") < 0 && playerInput == true)
		{
			//Debug.Log("Left");
			transform.Rotate(0, -90f, 0, Space.Self);
			StartCoroutine(WaitToTurn());
		}
		else if(Input.GetAxis("Horizontal") > 0 && playerInput == true)
		{
			//Debug.Log("Right");
			transform.Rotate(0, 90f, 0, Space.Self);
			StartCoroutine(WaitToTurn());
		}
	}
}
