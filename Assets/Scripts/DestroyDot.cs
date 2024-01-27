using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyDot : MonoBehaviour
{
	private GameManager gM;
	
	void Start()
	{
		gM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	private void OnCollisionEnter(Collision collision) //on colliding with dot increase player score and destroy dot
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
			gM.IncreaseScore();
        }
	}
}
