using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotScriptTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

public void OnCollisionEnter2D(Collision2D collision)
	{
	
		Destroy(gameObject);
	
	}
}
