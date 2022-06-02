using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targets : MonoBehaviour
{
    public int health =30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EatDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
