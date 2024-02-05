using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lives : MonoBehaviour
{
    public TextMeshProUGUI lives;
    public int livesAmount;

    
    void Start()
    {
        livesAmount = 3;
    }

    void Update()
    {
        
    }
}
