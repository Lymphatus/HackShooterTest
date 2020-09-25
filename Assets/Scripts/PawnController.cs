using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour
{
    protected virtual float MaxHealth { get; } = 100.0f;
    protected virtual float CurrentHealth { get; set; } = 100.0f;

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        OnTakeDamage();

        if (CurrentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTakeDamage()
    {
    }
}