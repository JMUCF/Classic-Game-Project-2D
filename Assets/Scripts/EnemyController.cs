using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform playerPos;
    private NavMeshAgent navMeshAgent;
	public GameObject player;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Start following the player
        StartCoroutine(FollowPlayer());
    }

    IEnumerator FollowPlayer()
    {
        while (player != null)
        {
            navMeshAgent.SetDestination(playerPos.position);
            yield return null;
        }
    }
	
	private void OnCollisionEnter(Collision collision) //on colliding with dot increase player score and destroy dot
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			Destroy(player);
        }
	}
}
