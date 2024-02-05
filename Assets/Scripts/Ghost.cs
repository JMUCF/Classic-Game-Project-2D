using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    public float health;
    public float maxHealth = 1;
    public int points = 100;

    private void start ()
{
    health=maxHealth;
}


}