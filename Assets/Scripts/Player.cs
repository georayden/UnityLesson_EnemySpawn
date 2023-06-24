using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int Health = 5;

    private void Update()
    {
        if(Health <= 0)
        {
            Die();
        }
    }    

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
